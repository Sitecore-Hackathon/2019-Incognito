# Documentation

## Summary

**Category:** Best use of xConnect and/or Universal Tracker

Purpose of module is to define Sitecore website user(contact) mood by analyzing data that he enters in forms on website. And depending on his mood show him different data. 

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

13. Open sc.package directory in this repository. Download ..... package.
14. Install ....... package on Sitecore instance. In case of any conflicts, please choose Overwrite option and continue.
15. Run smart publish of website
16. If you have used any other port from 8080 step then open `Emotion.Foundation.LexisAnalysis.config` configuration and change `Emotion.Foundation.LexisAnalysis.LexisTextAnalysisServerUrl` setting
17. Make additional configuration for XConnect. It is described [here](https://doc.sitecore.com/developers/91/sitecore-experience-platform/en/deploy-a-custom-model.html) in details
18. Open sc.package directory and download [XConnectEmotionModel, 0.1.json](../sc.package/XConnectEmotionModel,%200.1.json) file
19. Place `XConnectEmotionModel, 0.1.json` to `[xConnect root folder]\App_Data\Models` and `[xConnect root folder]\App_data\jobs\continuous\IndexWorker\App_Data\Models`
20. Copy `Emotion.Foundation.LexisAnalysis.dll` from Sitecore bin folder to `[xConnect root folder]\App_Data\jobs\continuous\AutomationEngine`
21. Open sc.package directory and download [sc.Emotions.xml](../sc.package/sc.Emotions.xml) file
22. Place `XConnectEmotionModel, 0.1.json` to `[xConnect root folder]\App_data\jobs\continuous\AutomationEngine\App_Data\Config\sitecore\Segmentation`
23. Navigate to `[Your Sitecore hostname]/feedback` page

## Configuration

No additional configuration is required. 
Only if you had some troubles with running python web application on port 8080, you will need to change configuration in `Emotion.Foundation.LexisAnalysis.config` file

```xml
<settings>
  <setting name="Emotion.Foundation.LexisAnalysis.LexisTextAnalysisServerUrl" value="http://localhost:8080/api/predict"/>
</settings>
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
