# Advent of Code 2025 - Day 1 - Parts 1 and 2 (COMPLETED)

This repository contains my solutions for Day 1 of the Advent of Code 2025 challenge, implemented in C#. The problem description is available on the [Advent of Code website](https://adventofcode.com/2025/day/1).

## Solution Overview

In this solution I chose to use a functional programming style to avoid the additional overhead of instatiation/object state. I broke the problem down into 2 parts:
1. Calculating the total number of full turns for a given rotation
2. Determining if the final partial turn passes 0 or not

The first problem we run into is the C# modulus operator, it is a remainder operator (not a true modulo) so it can return negative results. I started by creating helper methods to assist with translating rotation codes and modular arithmetic. 

The `Decode` method takes the dial initial positon and a set of rotation codes, it starts by counting the number of full turns, then checks if the remaining clicks cause the dial to pass 0. During these checks I had to go back over my logic multiple times to ensure I hadn't double counted. The decoding logic loops over each rotation in the sequence and completes these steps:

1. Get number of clicks to rotate and calculate the destination position. (Lines 36 - 37)
2. Divide number of clicks by dial size to get number of full turns. Add full turns to the password count. (lines 40 - 41)
3. Get the remainder of clicks / dial size to get the number of clicks in the partial turn (Line 44)
4. Check if the partial turn passes 0 by comparing the starting position and ending position of the partial turn. To avoid double counting this check is skipped if the start position is 0 as it was counted in the previous iteration. If the partial turn passes 0, increment the password count by 1. (Lines 55 - 59)
5. Set the previous position to the calculated destination (Line 63)

## Review
The Good: I think that breaking the problem down into small functional solutions helped keep the code clean and easy to read. It also made it easy to reuse helper functions and modify the main logic to handle the 2nd part of the problem.

The Bad: I think there are easier, cleaner ways to implement this but it requires a bit more research into modular arithmetic. I don't like the messy if statement used to check if the partial turn passes 0, I feel like there is a more elegant way to express it with fewer lines.

The Ugly: This could have a cool UI, or at least an ascii visualization of the dial turning. I would be fun to watch it spin and provides a visual aid for understanding the logic.