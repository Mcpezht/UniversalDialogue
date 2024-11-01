# UniversalDialogue
Show custom dialogue box using *-title -text -icon -form*.\
**REQUIRE .NET 8.0**

---

Arguments:\
-title <string>: Set the title of the dialogue box.\
-text <string>: Set the content of the dialogue box.\
-icon <string> [information, error, warning, question]: Set the icon of the dialogue box.\
-form <type> [messagebox, winforms]: Set the form type. WinForms will always on top.

---

Examples:\
ud.exe -title "Wait What?" -text "Do you have permission to execute this fucking command? I don't think so." -icon question -form messagebox\
[preview](https://github.com/user-attachments/assets/3e2be59d-e2f1-4f40-9afb-d75befe88d53)

ud.exe -title Warning -text "You don't have permission to execute this fucking command." -icon warning -form winforms\
[preview](https://github.com/user-attachments/assets/96c0f288-4f79-446b-af62-3142b1156f94)
