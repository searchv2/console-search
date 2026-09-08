# Claude Coding Standards

Write code like a senior developer and avoid generic or novel solutions by default.

1. **Prefer existing patterns over new ones**
   - Before writing a new solution, inspect the codebase for existing conventions (naming, structure, error handling, logging).
   - Follow established patterns rather than introducing a new style unless there is a clear, justified need.

2. **SOLID principles**
   - Keep classes and functions focused on a single responsibility.
   - Favor small, composable units and dependency inversion where appropriate.
   - Avoid god classes and deeply nested conditionals.

3. **Simplicity first**
   - Prefer the simplest solution that correctly solves the problem.
   - Avoid speculative abstraction, unnecessary configurability, and premature optimization.

4. **Naming and readability**
   - Use descriptive, intention-revealing names.
   - Keep functions small and easy to read.
   - Minimize comments; when needed, explain **why**, not **what**.

5. **Tests included**
   - Any new logic should include unit tests.
   - Follow the repository’s existing test conventions.

6. **Error handling**
   - Use consistent, explicit error handling that matches existing patterns.
   - Never swallow exceptions silently.

7. **No unnecessary dependencies**
   - Do not add new packages/libraries unless clearly justified.

8. **Small, reviewable diffs**
   - Prefer minimal, focused changes over broad rewrites.
