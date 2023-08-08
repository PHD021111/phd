pushd NhanVatGame
dotnet ef migrations add UpdateDatabase
dotnet ef database update
pause
popd