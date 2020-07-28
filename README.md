# MPQ Packer

A simple command line utility for generating custom WoW 3.3.5 Patches.

- Maximum size of 4gb
- ZLib Compression
- List File Generation
- Attributes File Generation

### Usage

`mpq-packer.exe path/to/folder path/to/path/patch-X.mpq`

### Linux Support

This has been tested on Ubuntu 20.04 using Wine and works well. 

I do strongly recommend however creating a 64bit WINEPREFIX for it.

Eg: `WINEPREFIX=~/.mpq-packer WINEARCH="win64" winecfg`

Then calling the command via `WINEPREFIX=~/mpq-packer wine mpq-packer.exe "Path_to_folder" "Path_to_MPQ"`