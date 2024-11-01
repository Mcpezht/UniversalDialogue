# UniversalDialogue
使用 *-title -text -icon -form* 显示自定义对话框。
**需要 .NET 8.0**

---

参数：
-title <string>：设置对话框的标题。\
-text <string>：设置对话框的内容。\
-icon <string> [information, error, warning, question]：设置对话框的图标。\
-form <type> [messagebox， winforms]：设置窗体类型。WinForms 将置顶。

---

例子：
ud.exe -title "等等什么？" -text "你他妈的有权执行这个命令吗？我不这么认为。" -icon warning -form messagebox
[预览](https://github.com/user-attachments/assets/27b2000f-3853-40c2-bb1b-ada701f83588)


ud.exe -title 警告 -text "你他妈的无权执行这个命令。" -icon warning -form winforms
[预览](https://github.com/user-attachments/assets/9e33f8bb-ccef-4cec-92e6-cb2da2dfd8c2)
