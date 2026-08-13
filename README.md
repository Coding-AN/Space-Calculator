![Logo](https://github.com/Aario-Wii/Space-Calculator/blob/main/Assets/CalcLogo.ico?raw=true)
# The Space Calculator
A Space-themed Calculator made in C# for Windows, MacOS, and Linux.\
Download it [**Here**](https://github.com/Aario-Wii/Space-Calculator/releases).
## How to use
<img width="343" height="373" alt="20260810-1034-39 6573447" src="https://github.com/user-attachments/assets/f1bd5b18-1df0-4fff-805c-b91f7d4c60d8" /> \
Click or tap on the Buttons use them. The Space Calculator functions just like a regular Calculator\
Hotkeys:
1. H: Toggle History
2. C: Clear
3. Shift + A: Toggle the Advanced Menu
4. Shift + -: Make Negative or Positive
5. A: Enter last answer into the display
6. Enter: Perform the Calculation
## Getting Started
1. Download the release binary corresponding to your Operating System **(All dependencies are bundled in)**
2. Unzip the Project
3. Launch the Executable
### How to get past Gatekeeper on MacOS (Only have to do the first time you open the file)
1. Go to settings and search for "developer"
2.  Select "Allow applications to use developer tools" and make sure that Terminal is enabled
    - If Terminal isn't there, press the plus button and add it
3. Open terminal, type in "chmod +x", and drag in the file from the zip that says CalculatorGUI inside
    - The terminal window should now say "chmod + x 'your-path-to-CalculatorGUI'"
4. Enter the command, then double click the CalculatorGUI file from Finder and click "Done" in the popup
5. Go to Privacy and Security in Settings, scroll down, and click Open Anyway
## Features
1. Contains the operations of a full basic calculator
2. Has support for negative numbers, parentheses, and grabbing the last answer calculated
3. Stores history, with options to delete entries, copy to clipboard, and input an entries value into the calculator
## How values are calculated
Rather than extracting numbers and operators from a string and calculating an answer, a string containing the expression is passed into a DataTable, which computes the answer; this approach was used in order to support more complex expressions and avoid calculating everything manually with switches and loops.
## Credits
* <a href="https://www.flaticon.com/free-icons/paper" title="paper icons">Paper icons created by Gregor Cresnar - Flaticon</a>
* Space.png was designed by Magnific (www.magnific.com)
* 3515498.png is from <a href="https://www.vecteezy.com/free-vector/recycle-bin">Recycle Bin Vectors by Vecteezy</a>
* The font Digital-7 was created by Alexander Sizenko.
### AI Usage
AI was used to help debug and confer with in order to learn how to solve problems\
**No code in this project was AI Generated**

---
**This project was made as a part of Hack Club Stardance**
