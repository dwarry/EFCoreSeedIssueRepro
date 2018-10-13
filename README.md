# EFCoreSeedIssueRepro
Minimal reproduction of the issue where seeding data fails if an Owned Entity is initialized by the parent class.

In `Domain.cs` there is a normal EF persistent entity which has an Owned Entity property. Seeding fails because the
Owned Entity is being initialized; it appears this is overwriting the values being set by EF. Comment out line 14 of 
`Domain.cs` and it works as you'd expect. 
