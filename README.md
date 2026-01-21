# Enneagram Short Scale (C# 14 & .NET 10)

## Description
This project implements a **RHETI-style Enneagram assessment** (short scale version) using C# 14 and .NET 10. It is designed as a lightweight, self-contained console application for exploring the Enneagram Type System - a personality framework that categorizes individuals into 9 distinct core types, each defined by unique core motivations, fears, and behavioral patterns.

### Key Features
- **RHETI-Aligned Logic**: Follows the core principles of the Riso-Hudson Enneagram Type Indicator (RHETI) - focusing on core motivations/fears (not surface-level behaviors) for accurate type assessment.
- **Concise Question Bank**: 72 carefully crafted questions (8 per Enneagram type) to balance depth and brevity.
- **5-Point Rating Scale**: Intuitive scoring system ("1 = Not at all" to "5 = Perfectly") with clear visual differentiation to avoid misinterpretation.
- **Automatic Wing Type Calculation**: Derives wing type (adjacent type with higher score) per Riso-Hudson guidelines, reflecting real-world personality complexity.
- **Self-Contained Execution**: Optimized for .NET 10 single-file publishing without external dependencies.
- **English Localization**: All assessment content and output are fully translated to standard Enneagram terminology (e.g., "Individualist/Romantic" for Type 4).

## Installation & Usage

### Prerequisites
- .NET 10 SDK installed on your machine (download: [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)).
- Compatible operating system (Windows/macOS/Linux - .NET 10 cross-platform support).

### Quick Start
1. Clone the repository and navigate to the project directory:
   ```bash
   git clone https://github.com/Pac-Dessert1436/Enneagram.ShortScale.git
   cd Enneagram.ShortScale
   ```
2. Compile and run the program directly (no project file required):
   ```bash
   dotnet run Enneagram.ShortScale.cs
   ```
3. Follow the on-screen instructions:
   - Rate each question from 1 (Not at all) to 5 (Perfectly) based on your true feelings.
   - After completing all questions, the program will generate a detailed report.

## Assessment Output Explanation
After completing the assessment, you will receive a report with 3 key sections:

### 1. Score Distribution
Shows your raw score for each Enneagram type (1–9), sorted from highest to lowest. Example:
```
Type4 (Individualist/Romantic): 35 points
Type5 (Investigator/Observer): 32 points
Type9 (Peacemaker/Mediator): 28 points
```

### 2. Core Type
Your highest-scoring type, with its core motivation and fear (per Riso-Hudson theory). Example:
```
[CORE TYPE] Type 4 (Individualist/Romantic)  
    Core Motivation: Pursues uniqueness and authenticity; wants to be meaningful and understood
    Core Fear: Fears mediocrity, being forgotten, losing self-uniqueness
```

### 3. Wing Type
The adjacent type with the next-highest score (influences your core type’s expression). Example:
```
[WING TYPE] Type 5 (Investigator/Observer)
    Note: Wing types influence the expression of core types, making personality more complex
```

## Important Notes
- **Non-Official Tool**: This is a RHETI-style simulation, not the official Riso-Hudson RHETI assessment. *__Results are for self-exploration only, not professional psychological diagnosis or commercial use.__*
- **Accuracy**: The assessment’s value depends on honest self-reflection. Answer questions based on your true feelings, not how you "should" behave.
- **Personality Fluidity**: Enneagram types reflect core patterns, not fixed labels. Your scores may shift based on life circumstances and personal growth.

## Acknowledgments
- Based on the Enneagram Type System developed by Don Richard Riso and Russ Hudson.
- Inspired by the Riso-Hudson Enneagram Type Indicator (RHETI) framework.
- Built with C# 14 and .NET 10, leveraging cross-platform and single-file execution features.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.