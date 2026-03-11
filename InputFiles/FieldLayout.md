# Input File Field Layouts

## PipeDelimited.txt

Pipe-delimited (`|`) file with line type indicators.

### Record Types

| Line Type | Description |
|-----------|-------------|
| 00 | Batch Header |
| 01 | Account Record |
| 02 | Detail / Charge Line |

### 00 - Batch Header
| Position | Field |
|----------|-------|
| 0 | Line Type (00) |
| 1 | File Date |
| 2 | Batch ID |

### 01 - Account Record
| Position | Field |
|----------|-------|
| 0 | Line Type (01) |
| 1 | Account ID |
| 2 | First Name |
| 3 | Last Name |
| 4 | Address |
| 5 | City |
| 6 | State |
| 7 | Zip |
| 8 | Email |
| 9 | Phone |

### 02 - Detail / Charge Line
| Position | Field |
|----------|-------|
| 0 | Line Type (02) |
| 1 | Account ID (links to parent 01 record) |
| 2 | Invoice ID |
| 3 | Invoice Date |
| 4 | Amount |
| 5 | Category (Medical, Dental, Vision) |

---

## CsvFile.txt

Comma-delimited file with a header row. Each row is a single record with one detail line. Note: this format does not include an invoice date field.

| Column | Field |
|--------|-------|
| id | Account ID |
| first_name | First Name |
| last_name | Last Name |
| address | Address |
| city | City |
| state | State |
| zip | Zip Code |
| email | Email Address |
| phone | Phone Number |
| invoice_id | Invoice ID |
| amount | Amount |
| category | Category (Medical, Dental, Vision) |

---

## FixedWidth.txt (Phase 4 only)

Fixed-width positional file with line type indicators.

### Record Types

| Indicator | Description |
|-----------|-------------|
| H | File Header |
| D | Account Record |
| L | Detail / Charge Line |

### H - File Header
| Start | Length | Field |
|-------|--------|-------|
| 0 | 1 | Line Type (H) |
| 1 | 10 | Batch ID |
| 11 | 8 | File Date (YYYYMMDD) |

### D - Account Record
| Start | Length | Field |
|-------|--------|-------|
| 0 | 1 | Line Type (D) |
| 1 | 6 | Account ID |
| 7 | 10 | First Name |
| 17 | 10 | Last Name |
| 27 | 18 | Address |
| 45 | 14 | City |
| 59 | 2 | State |
| 61 | 5 | Zip |
| 66 | 12 | Email |
| 78 | 10 | Phone |

### L - Detail / Charge Line
| Start | Length | Field |
|-------|--------|-------|
| 0 | 1 | Line Type (L) |
| 1 | 6 | Account ID (links to parent D record) |
| 7 | 10 | Invoice ID |
| 17 | 10 | Amount (zero-padded with explicit decimal: e.g. 00350.00) |
| 27 | 3 | Category Code (MED, DEN, VIS) |

### Category Code Mapping
| Code | Full Name |
|------|-----------|
| MED | Medical |
| DEN | Dental |
| VIS | Vision |
