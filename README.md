# Roundalize
Rounds and renders huge rational numbers to human-readable decimals.

## Overview
Coq will tend to give big rational numbers (Q) as numerator and denominator. These can be hundreds of digits long and aren't suitable for inclusion in papers or for most data analysis. Roundalize will turn those from a file that looks like this:

```
hello:61211:11345
world:33476:47196
```

Which are of the format `label:numerator:denominator` into this:

```
hello=5.3954
world=0.70929
```

This will work for arbitrarily large numbers.

## Usage
To use the utility, specify the input file path and precision (after the decimal point) as an integer. Results will be printed to stanard output, but are easy enough to redirect to a file using `>` as in the example below. If no precision is specified it will default to `6`.

```
Roundalize <file> [precision] > rounded.txt
```

## Acknowledgements
Fabulous public domain [Gist](https://gist.github.com/JcBernack/0b4eef59ca97ee931a2f45542b9ff06d) with the `BigDecimal` class by [Jan Christoph Bernack](https://github.com/JcBernack).
