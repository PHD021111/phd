pushd Game
dotnet ef migrations add UpdateDatabase2
dotnet ef database update
pause
popd