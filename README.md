Coding Test for Renkim

## About This Test

Please spend **2 to 3 hours** on this test. Feel free to take more time if you wish — make sure you are happy with your submission!

**Hint:** We are looking for a high-quality submission with great object oriented practices. Please take an object oriented approach and use LINQ queries when needed. Not a "get it done" approach.

Remember that this test is your opportunity to show us how you think. Be clear about how you make decisions in your code, whether that is with comments, tests, or how you name things.

## Project Setup

This is a **.NET 8 Console Application**. Open the solution in Visual Studio or your preferred IDE and build to verify it compiles before you begin.

The `InputFiles/` folder contains the test data files and a `FieldLayout.md` document that describes every field in each file format. The `ExpectedOutput/` folder contains sample outputs so you know the exact structure expected.

---

## Phase 1 — Parse Multiple File Formats

Parse the input files located in the `InputFiles/` folder into a **common data model**:

1. **PipeDelimited.txt** — A pipe-delimited (`|`) file with line type indicators (`00` = batch header, `01` = account record, `02` = detail/charge line). One account (01) can have multiple detail lines (02) beneath it.
2. **CsvFile.txt** — A comma-delimited file with a header row. Each row is a single record with one detail line.

Both formats represent the same type of data (accounts with charges) and should be normalized into the same internal representation. Refer to `InputFiles/FieldLayout.md` for exact field positions and descriptions.

Design your solution so that adding support for a new file format in the future would require adding new classes — not changing existing ones.

---

## Phase 2 — Apply Business Rules

Apply the following business rules to every record from both files, then print results to the console for **NY and FL records only**. Include all records for those states — both active and suppressed. Suppressed records should be clearly marked with the reason.

### Channel Determination

Determine the communication channel using this priority:

1. If the record has an **email address** → channel is **eNotice**
2. Else if the record has a **phone number** → channel is **SMS**
3. Otherwise → channel is **Print**

### Letter Code Assignment

Assign a letter code based on the category of the first detail/charge line:

| Category | Base Code |
|----------|-----------|
| Medical  | MED       |
| Dental   | DEN       |
| Vision   | VIS       |

Then prefix the base code based on the channel:

| Channel  | Prefix | Example    |
|----------|--------|------------|
| eNotice  | E      | EMED, EDEN |
| SMS      | T      | TMED, TDEN |
| Print    | (none) | MED, DEN   |

### Suppression Rules

A record should be suppressed (not included in output files, but still displayed in console) if any of the following are true:

- **Missing address**: the `address` field is empty or whitespace
- **Missing city or zip**: the `city` or `zip` field is empty or whitespace
- **Zero balance**: the sum of all detail line amounts for the record is zero or less

### Console Output

Display for each record: **Id, Name, State, Channel, LetterCode, TotalBalance, Status** (Active or SUPPRESSED with reason).

See `ExpectedOutput/SampleConsoleOutput.txt` for the expected format and data.

---

## Phase 3 — Generate Output Files

Generate **two JSON output files** in the project output directory for **non-suppressed records only** (from both input files combined):

### OutputHeader.json

An array of objects, each containing:

```json
{
  "id": "1001",
  "firstName": "John",
  "lastName": "Smith",
  "address": "123 Main St",
  "city": "New York",
  "state": "NY",
  "zip": "10001",
  "letterCode": "EMED",
  "channel": "eNotice",
  "totalBalance": 225.00
}
```

### OutputDetails.json

An array of objects for all detail/charge lines belonging to non-suppressed records:

```json
{
  "parentId": "1001",
  "invoiceId": "INV-001",
  "amount": 150.00,
  "category": "Medical"
}
```

See `ExpectedOutput/SampleOutputHeader.json` and `ExpectedOutput/SampleOutputDetails.json` for the exact JSON structure. These samples show the format for a single record — your output should include **all non-suppressed records** from both input files. A downstream system consumes these files — the property names and types must match exactly.

---

## Phase 4 — Extensibility Challenge

A third file format has arrived: **FixedWidth.txt** (already in the `InputFiles/` folder). See `InputFiles/FieldLayout.md` for the field positions.

- Add support for parsing this file **without modifying any of your existing parser classes** from Phases 1–3
- The fixed-width records should flow through the exact same business rules, console output, and file generation logic
- If your design requires changes to existing classes to support this, refactor first, then add the new parser

**Bonus question (written answer in comments or a text file):**

> Assume `PipeDelimited.txt` could contain 500,000+ account records with an average of 5 detail lines each. What would you change in your solution to handle this efficiently? Consider memory usage and processing time.

---

## Submission

When you are finished:

1. Ensure your application compiles and runs
2. Verify the console output matches the expected output for NY and FL records
3. Verify both JSON output files are generated correctly
4. Zip your solution and email it to nbeatty@renkim.com,vpratapaneni@renkim.com

Good luck!
