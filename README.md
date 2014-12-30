PathSplit
=========

A .NET custom path split method which use '\' as escape character.

Examples:
```c#
// User '/' as delimetter
Splitter.SplitPath("a/b/c") ->> {"a", "b", "c"}
```
```c#
// User '/' as delimetter
Splitter.SplitPath("a\/b") ->> {"a/b"}
```
```c#
// User '/' as delimetter
Splitter.SplitPath(@"a\\\\\/b") ->> {"a\\/b"}
```
```c#
// User '/' as delimetter
Splitter.SplitPath("a\//b/c\\") ->> {"a/", "b", "c\"}
```
```c#
// User '@' as delimetter
Splitter.SplitPath("a@b@c\@",'@') ->> {"a", "b", "c@"}
```

