# youtube-clone

## Migration Commands

```bash
$ cd VideoClone.DataAccess
$ dotnet ef migrations add <migration-name> --startup-project ../VideoClone.WebAPI --output-dir Migrations
$ dotnet ef database update --startup-project ../VideoClone.WebAPI
```
