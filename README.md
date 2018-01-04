# Roundalize
Rounds and renders huge rational numbers to human-readable decimals.

## Overview
Coq will tend to give big rational numbers (Q) as numerator and denominator. These can be hundreds of digits long and aren't suitable for inclusion in papers. Roundalize will turn those from a file that looks like this:

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

## Acknowledgements
Fabulous public domain [Gist](https://gist.github.com/JcBernack/0b4eef59ca97ee931a2f45542b9ff06d) with the `BigDecimal` class by [Jan Christoph Bernack](https://github.com/JcBernack).
