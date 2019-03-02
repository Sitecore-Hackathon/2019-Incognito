# Documentation

The documentation for this years Hackathon must be provided as a readme in Markdown format as part of your submission. 

You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.

Examples of things to include are the following.

## Summary

**Category:** Hackathon Category

What is the purpose of your module? What problem does it solve and how does it do that?

## Pre-requisites

Module dependencies

- Sitecore 9.1 (XP0)
- Python 3+ (including PIP package manager)
- NodeJS (including NPM package manager)

## Installation

1. Module depends on Python web based application that analyzes given user text input using SVM and provides the emotion(s) 
2. Navigate to [SubModule](https://github.com/frisibeli/lexis-text-analysis/tree/b20b13c39d53e26a8518e41689aa4df81158ddd7) for more details
3. Install Python 3 (If you don't have it)
4. Install NodeJS (If you don't have it)
5. Install virtualenv
```cmd
pip install virtualenv
```
6. Clone the repository
```
git clone https://github.com/frisibeli/lexis-text-analysis.git
```
7. Initialize and activate virtualenv
```
cd lexis-text-analysis/backend
virtualenv -p python3 .
```
if it throws error then try 
```
virtualenv env -p C:/Python37/python.exe
```
8. Assuming that you have already initialized virtualenv and you are in `lexis-text-analysis/backend`:
Install python requirements using pip
```
pip install -r requirements.txt
```
9. Execute application
```
python app.py
```
Expected result: The app on port 8080 was started. It is by default, but you could be changed in app.py

10. Veryfy that python web app works: 11-12 steps
11. Navigate to `lexis-text-analysis/frontend` and execute `npm install`
12. Execute `npm start`
Expected result: React web application on 3000 port is started, you are able to send text data and recieve graph with emotions

13.


Use the Sitecore Installation wizard to install the [package](#link-to-package)
2. ???
3. Profit

## Configuration

How do you configure your module once it is installed? Are there items that need to be updated with settings, or maybe config files need to have keys updated?

Remember you are using Markdown, you can provide code samples too:

```xml
<?xml version="1.0"?>
<!--
  Purpose: Configuration settings for my hackathon module
-->
<configuration xmlns:patch="http://www.sitecore.net/xmlconfig/">
  <sitecore>
    <settings>
      <setting name="MyModule.Setting" value="Hackathon" />
    </settings>
  </sitecore>
</configuration>
```

## Usage

Provide documentation  about your module, how do the users use your module, where are things located, what do icons mean, are there any secret shortcuts etc.

Please include screenshots where necessary. You can add images to the `./images` folder and then link to them from your documentation:

![Hackathon Logo](images/hackathon.png?raw=true "Hackathon Logo")

You can embed images of different formats too:

![Deal With It](images/deal-with-it.gif?raw=true "Deal With It")

And you can embed external images too:

![Random](https://placeimg.com/480/240/any "Random")

## Video

Please provide a video highlighing your Hackathon module submission and provide a link to the video. Either a [direct link](https://www.youtube.com/watch?v=EpNhxW4pNKk) to the video, upload it to this documentation folder or maybe upload it to Youtube...

[![Sitecore Hackathon Video Embedding Alt Text](https://img.youtube.com/vi/EpNhxW4pNKk/0.jpg)](https://www.youtube.com/watch?v=EpNhxW4pNKk)
