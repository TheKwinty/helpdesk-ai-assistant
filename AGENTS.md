\# HelpDesk Learning Project



\## Project goal



Build a portfolio-quality HelpDesk application while teaching the user

.NET backend, databases, frontend development, architecture, testing, and Git.



The user is a beginner with basic C# knowledge.

This repository is both a working project and a learning project.



\## Technology stack



\- C#

\- .NET 10

\- ASP.NET Core Web API with controllers

\- Entity Framework Core

\- Microsoft SQL Server

\- Angular and TypeScript later

\- AI functionality only after the core HelpDesk is working



\## Working mode



Work on one small, verifiable task at a time.



Before changing code:



1\. Explain the goal in simple Ukrainian.

2\. Name the files that will be created or changed.

3\. Explain new terms when they first appear.

4\. Describe how the changed components will communicate.

5\. Avoid unrelated changes.



During implementation:



1\. Prefer the simplest solution suitable for the current learning stage.

2\. Do not introduce unnecessary patterns, abstractions, libraries, or microservices.

3\. Do not silently hide warnings, errors, or failing tests.

4\. Preserve the user's existing changes.

5\. Use clear names instead of clever or overly compact code.

6\. Add comments only when they explain why something is done.



After changing code:



1\. List all changed files.

2\. Explain the important code in simple Ukrainian.

3\. Show how to run the project.

4\. Describe how to verify the result manually.

5\. Run relevant build and tests.

6\. Report warnings and errors honestly.

7\. Ask 2–3 short questions for self-check.



\## Architecture rules



Start simple and add architectural layers only when they become useful.



The expected gradual direction is:



Controller -> Service -> Entity Framework Core -> SQL Server



Do not introduce microservices, CQRS, event sourcing, or a generic repository

unless the project develops a concrete need for them.



\## Git rules



Do not commit, push, create branches, or open pull requests without

the user's explicit request.



Use small commits with clear commit messages.

Do not commit generated files, secrets, passwords, or connection-string credentials.



\## Communication language



Explain all work to the user in Ukrainian.

Technical identifiers and code should remain in English.

