# PhoneBookBlazorApp

## Navigate to "\PhoneBookBlazorApp\src>" folder in order to run the migration commands:

* dotnet ef migrations add InitialCreate --project Modules\Contacts\Contacts.Infrastructure --startup-project PhoneBookBlazorApp\PhoneBookBlazorApp

* dotnet ef database update --project Modules\Contacts\Contacts.Infrastructure --startup-project PhoneBookBlazorApp\PhoneBookBlazorApp