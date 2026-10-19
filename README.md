# Baobab Ridge Wildlife Rehabilitation Records System

**PRG2782 Project 2026**  
Belgium Campus – Programming 2782

A C# Windows Forms desktop application that records every animal in care at the fictional Baobab Ridge Wildlife Rehabilitation Centre. The application calculates each animal’s **Status** and **Housing Unit** from the vet’s Recovery Score and produces a summary report for the Centre manager.

Data is stored in plain text files only (no databases).

---

## Team

| Name | Student Number | Role / Feature Ownership |
|------|----------------|--------------------------|
| vusi123-hash | (add your number) | Full implementation (Add, View, Update/Search, Delete, Summary) |

> Replace the placeholder with your real student number and add any group members.

---

## How to Build and Run

1. Clone the repository:
   ```bash
   git clone https://github.com/vusi123-hash/BaobabRidgeWildlifeRehabilitationRecordsSystem.git
   cd BaobabRidgeWildlifeRehabilitationRecordsSystem
   ```

2. Open the solution / project in **Visual Studio 2022** (or later) with the **.NET 8** workload installed.

3. Build the project (Ctrl+Shift+B). The starter `animals.txt` is copied to the output folder automatically.

4. Run the application (F5 or Ctrl+F5).

Requirements:
- .NET 8.0 (or newer) Windows desktop workload
- Windows OS (Windows Forms)

---

## Features

1. **Add Animal** – Validate all fields, calculate Status & Housing Unit, append to `animals.txt`.
2. **View Animals** – Load and display all valid records in a read-only DataGridView.
3. **Search & Update** – Exact, case-insensitive ID search **or** select a row in the grid. Enter Edit mode (ID read-only, Add disabled, Save Changes enabled). Save rewrites only the changed record.
4. **Delete Animal** – Select a row → confirmation dialog → remove from file and grid.
5. **Summary Report** – Calculate totals, averages and per-status counts. Display on the form **and** write `summary.txt`.

---

## File Formats

### animals.txt
- One animal per line, seven fields separated by `|`:
  `ID | Name | Species | Age | Score | Status | Housing Unit`
- No header, no blank lines, UTF-8 encoding.
- Located in the same folder as the running `.exe`.
- Starter file contains 10 valid records covering all five statuses.

### summary.txt
- Generated (overwritten) every time the user clicks **Generate Summary**.
- Exact layout required by the brief (timestamp `yyyy-MM-dd HH:mm`, averages with two decimal places using a full stop).

---

## Classification Rules (single method)

| Recovery Score | Status         | Housing Unit            |
|----------------|----------------|-------------------------|
| 0–19           | Critical       | Intensive Care Unit     |
| 20–39          | Serious        | High-Dependency Ward    |
| 40–59          | Stable         | Recovery Ward           |
| 60–79          | Recovering     | Outdoor Enclosure       |
| 80–100         | Release-Ready  | Pre-Release Camp        |

The logic lives in **one method** (`Animal.Classify`) that is called by both Add and Update.

---

## Error Handling

- Missing / locked / permission-denied file scenarios are caught and shown with friendly messages.
- Malformed lines in `animals.txt` are skipped (user is told how many).
- Empty fields, non-numeric age/score, invalid ID format, etc. are validated with clear messages and focus returned to the offending control.
- The application never crashes with an unhandled exception under normal use.

---

## Known Limitations

- Single-user desktop application (no concurrent multi-user locking beyond basic IOException handling).
- Animal ID cannot be changed after the record is created (by design).
- Summary averages use invariant culture (full stop decimal separator) as required.

---

## GitHub Repository

https://github.com/vusi123-hash/BaobabRidgeWildlifeRehabilitationRecordsSystem
