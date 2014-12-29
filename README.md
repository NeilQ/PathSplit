PathSplit
=========

A .NET custom path split method which use '/' as delimetter.

Examples:
```c#
Splitter.SplitPath("a/b/c") -> {"a", "b", "c"}
```
```c#
// User '\' as token
Splitter.SplitPath("a\/b") -> {"a/b"}
```
```c#
// User '\' as token
Splitter.SplitPath("a\\\\\/b") -> {"a\\,b"}
```
```c#
// User '\' as token
Splitter.SplitPath("a\//b/c\\") -> {"a/", "b", "c\"}
```
```c#
// User '@' as token
Splitter.SplitPath("a@/b") -> {"a/b"}
```

