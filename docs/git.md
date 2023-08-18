# A2SV Project Git Workflow Guide

Welcome to the Git Usage Guideline for A2SV Projects. This comprehensive document will provide you with a clear and effective workflow for using Git within the A2SV Portal project and other A2SV projects. By following these guidelines, you'll be able to collaborate seamlessly, manage version control, and contribute effectively to the project.

## Table of Contents

1. [Introduction](#introduction)
2. [Git Workflow](#git-workflow)
    - [Getting Started](#getting-started)
    - [Creating and Managing Branches](#creating-and-managing-branches)
    - [Making Changes](#making-changes)
    - [Stage and Commit Changes](#stage-and-commit-changes)
    - [Pushing Changes](#pushing-changes)
    - [Creating Pull Requests](#creating-pull-requests)
3. [Pull Request Guidelines](#pull-request-guidelines)
4. [Git FAQs](#git-faqs)
5. [Conclusion](#conclusion)

## Introduction

This document serves as a comprehensive guide for using Git effectively within the A2SV projects. It aims to establish a consistent Git workflow, covering topics such as branching, making changes, committing, pushing, and creating pull requests. By adhering to these guidelines, you'll ensure that the codebase remains organized, maintainable, and scalable.

## Git Workflow

### Getting Started

1. Clone the repository to your local machine using:
   ```
   git clone [repository-url]
   ```

2. Configure Git to rebase when pulling changes:
   ```
   git config pull.rebase true [--global]
   ```

3. Pull changes from the main branch:
   ```
   git pull origin main
   ```

### Creating and Managing Branches

- Create a new branch for each feature or bug fix:
  ```
  git checkout -b [branch-name]
  ```
  Example: `git checkout -b aait.bac.g1a.bruk-tedla.login`

- Use `git stash` to organize changes when switching branches.

- Rebase your branch with changes from the main branch:
  ```
  git checkout main
  git pull
  git checkout [branch-name]
  git pull origin main
  ```

### Making Changes

- Make small, focused commits that address a single issue or feature.

### Stage and Commit Changes

- Stage changes:
  ```
  git add [file-name]
  ```

- Commit changes with a meaningful message:
  ```
  git commit -m "fix(AAiT-backend-1A): Update Login Page"
  ```

### Pushing Changes

- Push changes to the remote branch:
  ```
  git push
  ```

### Creating Pull Requests

1. Ensure your branch is up to date with the main branch:
   ```
   git pull --rebase origin main
   ```

2. Create a pull request on GitHub, ensuring to add appropriate reviewers.

3. Address any reviewer comments and make necessary changes.

4. Rebase your branch with changes from the main branch before merging:
   ```
   git pull --rebase origin main
   ```

5. Merge the pull request:
   - Choose "Squash and Merge" to group smaller commits.

6. After merging, rebase your branch again to stay up to date:
   ```
   git pull origin main
   ```

## Pull Request Guidelines

When creating a pull request, please ensure that:

- PR title follows the commit convention, eg: "fix(AAiT-backend-1A): Update Login Page"
- Your branch is up to date with the main branch.
- Changes are fully tested and pass all tests.
- Commit messages are meaningful and follow the commit guidelines.

## Git FAQs

Refer to the [Git FAQs](#git-faqs) section for answers to common Git-related questions.

## Conclusion

Congratulations! You have completed the Git Workflow Guide for A2SV Projects. By following these best practices, you contribute to a well-organized, maintainable, and scalable codebase. If you encounter any questions or issues, don't hesitate to reach out to your team leader for assistance. Happy coding!
