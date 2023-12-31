## Variable and Constant Naming Rules

### 1. **Use Descriptive Names**

   - Variables and constants should have descriptive names that convey their purpose and usage.
   - Avoid single-letter or ambiguous names like `x`, `i`, or `temp`. Instead, use names like `playerHealth` or `enemyCount`.

### 2. **CamelCase for Variables**

   - Use camelCase for variable names (e.g., `playerScore`, `enemyHealth`).
   - Start with a lowercase letter and capitalize the first letter of each subsequent word within the name.

### 3. **UPPER_CASE for Constants**

   - Use uppercase letters and underscores for constant names (e.g., `MAX_ENEMY_COUNT`, `PI_VALUE`).
   - Constants should be declared using `const` or `static readonly` and should not change their value during runtime.

### 4. **Avoid Abbreviations**

   - Minimize the use of abbreviations, acronyms, or shortened words in variable and constant names unless they are widely accepted and understood in the domain.
   - Prefer clarity over brevity.

### 5. **Namespace Prefix (if applicable)**

   - When appropriate, use namespace prefixes to avoid naming conflicts. For example, `UI_PlayerName` instead of `PlayerName`.

### 6. **Pluralize for Collections**

   - Use plural nouns for variables that represent collections or arrays. For example, `playerNames` instead of `playerNameArray`.

### 7. **Boolean Variable Clarity**

   - Boolean variables should start with verbs or adjectives that make their purpose clear. For example, `isRunning` or `hasCompletedTutorial`.

### 8. **Avoid Hungarian Notation**

   - Avoid using Hungarian notation (e.g., `strPlayerName`, `intScore`) as it can make the code less readable.

### 9. **Avoid Reserved Words**

   - Do not use reserved words or keywords as variable or constant names.

### 10. **Avoid Special Characters**

   - Avoid special characters like `$`, `@`, or `!` in variable names, as they can make code harder to read.

## Example Variable and Constant Naming:

```csharp
// Variables
int playerScore;
float playerHealth;
string playerName;

// Constants
const int MAX_ENEMY_COUNT = 10;
static readonly float PI_VALUE = 3.14159265f;
```