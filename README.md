This is based off [the wonderful article/series](https://blog.adamfurmanek.pl/2016/04/30/custom-memory-allocation-in-c-part-2/) by [@furmanekadam](https://twitter.com/furmanekadam) that explores using unsafe code to allocate memory.  This repository features x64 version of this code.  Do NOT try to run this on x86!

[Benchmark.NET Version Here](https://github.com/Mike-EEE/BenchmarkDotNet.UnsafeListx64)

```
------------------------
Array
Insertion time: 1346
Sum: 1571577856
Calculation time: 82
Array
Insertion time: 1599
Sum: 1571577856
Calculation time: 74
Array
Insertion time: 1816
Sum: 1571577856
Calculation time: 75
Array
Insertion time: 1439
Sum: 1571577856
Calculation time: 76
Array
Insertion time: 1763
Sum: 1571577856
Calculation time: 75
------------------------
UnsafeList
Insertion time: 1073
Sum: 1571577856
Calculation time: 135
UnsafeList
Insertion time: 1065
Sum: 1571577856
Calculation time: 130
UnsafeList
Insertion time: 1039
Sum: 1571577856
Calculation time: 110
UnsafeList
Insertion time: 1035
Sum: 1571577856
Calculation time: 132
UnsafeList
Insertion time: 1699
Sum: 1571577856
Calculation time: 165
```