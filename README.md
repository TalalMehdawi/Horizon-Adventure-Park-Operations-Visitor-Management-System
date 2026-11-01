# Horizon Adventure Park — Operations & Visitor Management System

A C# console application that simulates the daily operations of a mid-sized theme park,
replacing paper-based visitor logs and manual ride queues. Visitors are registered, tickets
are issued and validated, ride eligibility and capacity are enforced, reservations are managed,
and staff assignments are tracked — all through a simple numbered console menu.

All data is stored **in memory only** (per the assignment requirements): nothing is saved when
the program exits.

---


## Learning Goal

I built this project while learning **Clean Architecture**. I organized the code into
Presentation, Application, Domain, and Infrastructure layers, but I'm aware that this is
not a true Clean Architecture implementation: the separation is basic and does not strictly
follow its principles.
I kept the project as a learning milestone, and I applied what I learned from it in my later projects.


---

## Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) (the project targets .NET 10)

## How to Run

**Option 1 — terminal:**

```bash
cd "Horizon Adventure Park"
dotnet run
```

**Option 2 — IDE:**

Open `Horizon Adventure Park.sln` in JetBrains Rider or Visual Studio and run the project.

The main menu appears immediately:

```
======================================================
Welcome To The Horizon Adventure Park System
======================================================
	[1] Add Visitor
	[2] Issue Ticket
	[3] Edit Ticket Status
	[4] Validate Ride Access
	[5] Create Reservation
	[6] Cancel Ride Reservation
	[7] View Rides Occupancy
	[8] Add New Ride
	[9] Manage Ride Status
	[10] Assign Staff
	[11] Print Assigned Staff
	[12] Exit
```

---

## Implemented Features

### Visitors & Ticketing
- **Register visitors** with name, age, height, category (Child / General / Senior / VIP),
  and accompanying-adult flag for children.
- **Issue tickets** automatically priced by visitor category
  (Child 15.5 · General 20 · Senior 30 · VIP 40), valid for one day from issue time.
- **Update ticket status** (Active / Expired / Cancelled).

### Ride Access & Reservations
- **Validate ride access** — checks every requirement individually and reports the *specific*
  failed one: age, height, ticket tier, ticket validity/status, accompanying-adult rule,
  and whether the ride is currently open.
- **Create reservations** per time slot (Morning / Afternoon / Evening), subject to the ride's
  capacity and a duplicate check on the same visitor + slot.
- **Cancel reservations** — cancelled reservations free their capacity and stop blocking new ones.
- **View occupancy** — number of active reservations for any ride in any time slot.

### Ride & Facility Management
- **Add new rides** with capacity, status, minimum age/height, minimum ticket category,
  and accompanying-adult requirement.
- **Update ride operational status** (Open / Closed / Under Maintenance).
  Admissions and reservations against non-open rides are blocked.

### Staff Management
- **Assign employees** to rides per time slot. Conflicts are rejected: an employee can hold
  only one assignment per slot, and each ride/slot has a single assigned operator.
- **Print assigned staff** — lists every staff assignment (employee, ride, and time slot).

---

## Demo Data (pre-loaded at startup)

**Rides**

| ID    | Name            | Capacity | Status           | Min Age | Min Height | Min Ticket |
|-------|-----------------|----------|------------------|---------|------------|------------|
| R-101 | Sky Screamer    | 20       | Open             | 12      | 140        | Child      |
| R-102 | Splash Lagoon   | 30       | Open             | 6       | 110        | General    |
| R-103 | Kiddie Carousel | 25       | Open             | 3       | 90         | Senior     |
| R-104 | Dragon Coaster  | 16       | Under Maintenance| 14      | 150        | General    |
| R-105 | Giant Wheel     | 40       | Closed           | 5       | 100        | VIP        |

**Employees:** E-101 Omar Haddad · E-102 Lina Farah · E-103 Karim Nasser · E-104 Sara Malhas

**ID prefixes** so you always know what you're looking at:
`V-` visitor · `T-` ticket · `R-` ride · `RES-` reservation · `E-` employee · `A-` staff assignment

---

## Quick Test Walkthrough

1. `[1]` Register a visitor (e.g., age 25, height 170, General) → note the returned `V-...` ID.
2. `[2]` Issue a ticket using that visitor ID → note the `T-...` ID.
3. `[4]` Validate ride access for ride `R-104` → denied: ride is under maintenance.
4. `[4]` Try `R-101` → denied: below minimum age (12).
5. `[5]` Create a reservation on `R-101` with your ticket, Morning slot → confirmed.
6. `[7]` View occupancy of `R-101`, Morning → shows 1.
7. `[6]` Cancel the reservation using its `RES-...` ID, then repeat step 5 → allowed again.
8. `[10]` Assign employee `E-101` to `R-101`, Morning → confirmed; try the same again → rejected as a conflict.
9. `[11]` Print assigned staff → shows the assignment from step 8 (employee, ride, slot).

---

## Project Structure

```
Horizon Adventure Park/
├── Program.cs                     — entry point, starts the menu loop
├── Presentation/                  — console UI (menu screens, ticket printing)
├── Application/                   — use-case layer (menu actions, input reading, validation logic)
├── Domain/
│   ├── Entities/                  — Visitor, Ticket, Ride, Reservation, Employee, EmpAssgin
│   └── Enums/                     — categories, statuses, time slots, menu options
└── Infrastructure/
    └── Repositories/              — in-memory stores (array-backed) for each entity
```

Console I/O lives in `Presentation`/`Application`; business entities and rules live in `Domain`;
data storage lives in `Infrastructure`. This layout is my first attempt at Clean Architecture,
so it follows the idea of separating responsibilities without claiming to be a perfect example of it.

---

## Authorship Note

This project was completed by **Talal Mehdawi** as a Training assignment.

An AI coding assistant was used strictly as a *mentor*: explaining concepts, reviewing
the code, pointing out bugs, and suggesting design approaches. **All of the code in this
repository was written by me**, and every design decision was made after discussing the
trade-offs myself.