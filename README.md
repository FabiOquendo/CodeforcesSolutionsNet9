# Codeforces Solutions (.NET 9 & C# 13)

This repository contains my solutions to competitive programming problems on **Codeforces**, optimized for the **.NET 9** runtime and leveraging the latest **C# 13** features.

## Technologies & Tools
*   **Language:** C# 13
*   **Framework:** .NET 9 (Standard Term Support)
*   **IDE:** Visual Studio 2026
*   **I/O Strategy:** Custom `Scanner` class based on `StreamReader` and a manual-buffered `StreamWriter` for high-performance execution.

## Template Structure
I utilize a **Top-level statements** architecture to minimize boilerplate, allowing a direct focus on algorithmic logic:

**Fast I/O Setup:** `StreamWriter` configuration with `AutoFlush = false` to minimize system calls.
**Custom Scanner:** Token-based reading to prevent memory overhead and ensure $O(1)$ access to input data.
