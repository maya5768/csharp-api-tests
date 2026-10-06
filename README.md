# csharp-api-tests

פרויקט תשתית לבדיקות אוטומטיות של REST API, בנוי ב-C# עם xUnit.

## סקירה

הפרויקט מדגים הקמת סוויטת בדיקות אוטומטיות ל-API חיצוני ([JSONPlaceholder](https://jsonplaceholder.typicode.com/))
באמצעות **xUnit** ו-**HttpClient**, עם דגש על מבנה נקי וטסטים קריאים.

## טכנולוגיות

- .NET 10
- xUnit
- HttpClient
- JsonSchema.Net (אימות תשובות מול JSON Schema)
- GitHub Actions (CI)

## הרצת הבדיקות

```
dotnet test ApiTests
```

הבדיקות רצות גם אוטומטית ב-GitHub Actions, בכל Pull Request ובכל push ל-`main` (`.github/workflows/tests.yml`).

## מבנה הפרויקט

```
ApiTests/
├── ApiTests.csproj
├── Configuration/
│   └── ApiSettings.cs          # base URL and timeout
├── Models/
│   ├── Post.cs                 # response model
│   └── CreatePostRequest.cs    # request model
├── Clients/
│   ├── ApiClientBase.cs        # shared HTTP plumbing
│   └── PostsApiClient.cs       # /posts actions
├── Fixtures/
│   └── ApiClientFixture.cs     # one shared HttpClient per test class
├── Validation/
│   ├── JsonSchemaValidator.cs  # wraps JsonSchema.Net
│   └── SchemaValidationResult.cs # library-free result
├── TestData/
│   └── PostTestData.cs         # named test input
├── Schemas/
│   └── post.schema.json        # JSON Schema contract for a post
└── Tests/
    └── PostApiTests.cs         # test class
```

הבדיקות לא שולחות HTTP בעצמן. הן קוראות לפעולות של `PostsApiClient`, בדומה ל-Page Object Model בבדיקות UI.

## תיעוד מורחב

- המסמך הנוכחי: אסטרטגיית הבדיקות, ארכיטקטורת הקוד, תיעוד המחלקות, ששת מקרי הבדיקה עם הקוד שלהם, ומפת הדרכים שמומשה — ראו [מסמך תכנון בדיקות, גרסה 2](<ApiTests – מסמך תכנון בדיקות-VER2.html>).
- התכנון המקורי, לפני המימוש — ראו [מסמך תכנון בדיקות, גרסה 1](<ApiTests – מסמך תכנון בדיקות.html>).
- לתיעוד שיטת העבודה עם Git (branching, Pull Requests, Squash merge) — ראו [git-workflow.html](git-workflow.html).
