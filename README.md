# MAS For 7

I hate fake "We no longer support Windows 7" statements, especially when they come from 
big hardware corporations. Intel SSD toolbox reached EOL at the end of 2020, meaning 
that Windows 7 users were left without an up-to-date Toolbox for their Intel SSDs.

Intel states on their Intel Memory and Storage Tool (CLI) and Solidigm Storage Tool (CLI) download page that Windows 7 
is no longer supported - when in reality, the Command Line executable works without any problems whatsoever.

MAS For 7 is a simple GUI tool for older versions of Windows that works with "Intel Memory and Storage Tool" and "Solidigm Storage Tool". 
It provides the same basic functionalities as its predecessor, all of which are carried out using the official 
IntelMAS and SST Command Line Executables, such as:

- SSD optimization.

- Diagnostic Scans.

- Firmware Upgrade.

- SMART and Sensor information.


## Installation

- Download and Install [Intel's Memory and Storage Tool CLI](https://www.intel.com/content/www/us/en/download/19520/736794/intel-memory-and-storage-tool-cli-command-line-interface.html) (LATEST TESTED VERSION 1.12) or download [Solidigm Storage Tool CLI](https://www.intel.com/content/www/us/en/download/19520/736794/intel-memory-and-storage-tool-cli-command-line-interface.html) (LATEST TESTED VERSION 1.1).
- Download and run "MAS for 7".
- Specify the "Intel Memory and Storage" or "Solidigm Storage Tool" installation path.


## FAQ

#### Doesn't Windows 7 have SSD optimization (TRIM) built into it?
Yes, however there are some features that came with the SSD Toolbox that may have been useful to some users. 

#### Do I need MAS for 7?
No, you don't need this application to have a smooth experience with your Intel SSD - but if you are running an unsupported OS and you want a functional GUI for Intel's or Solidigm's Storage tool, this tool simplifies things.

#### Does it work with Windows XP / Windows Vista?
Yes. (Windows 7 is more popular, hence the name :P )

#### Is it a virus?
The entire Visual Studio Solution can be found here. You can double check the code behind it yourself. Since the executable scans for Media Storage Drives, you may receive a warning from your Antivirus.

#### Why would anyone develop such a tool?
Good practise... and it looks good on my CV.

#### Can I use/copy ****? I need it for my project...
Go ahead!


## Feedback

If you have any feedback, please reach out to me at gavenatore@gmail.com.


## License

[MIT](https://choosealicense.com/licenses/mit/)

