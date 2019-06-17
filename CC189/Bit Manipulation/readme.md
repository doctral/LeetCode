# Bit Manipulation

## Arithmetic VS Logical Shift
1. Arithmetic Shift (>>, <<)
2. Logical Shift (>>>, <<<)
3. Arithmetic Left Shift and Logical Left Shift have the same result
4. Arithmetic Right Shift (>>) shift values to the right but fill in the new bits with the value of the sign bit (+/- reserved), this has effect of dividing by two.
5. Logical Right Shift (>>>) shift the bits and put a 0 in the most significant bit (+/- not reserved).
6. In C#, there is only >>.
    1. If the first operand is of type int or long, >> will perform an arithmetic shift.
    2. If the first operand is of type uint or ulong, >> will perform a logical shift.
