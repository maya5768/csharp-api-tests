# csharp-api-tests

פרויקט תשתית לבדיקות אוטומטיות של REST API, בנוי ב-C# עם xUnit.

## סקירה

הפרויקט מדגים הקמת סוויטת בדיקות אוטומטיות ל-API חיצוני ([JSONPlaceholder](https://jsonplaceholder.typicode.com/))
באמצעות **xUnit** ו-**HttpClient**, עם דגש על מבנה נקי וטסטים קריאים.

## טכנולוגיות

- .NET 10
- xUnit
- HttpClient
- JsonSchema.Net (לבדיקות סכמת JSON עתידיות)

## הרצת הבדיקות

```
dotnet test
```

## מבנה הפרויקט

```
ApiTests/
├── ApiTests.csproj
└── PostApiTests.cs
```

## תיעוד מורחב

להסבר מפורט על אסטרטגיית הבדיקות, מבנה הפרויקט ותוכנית הפיתוח — ראו [README.html](README.html).
