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
14. Install ....... package on Sitecore instance. In case of any conflicts, please choose Merge-Clear option and continue.
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

Module is build on [open source Python web application](https://github.com/Antonytm/lexis-text-analysis). This application uses support-vector machine to get emotion(s) from the text. Model was trained on 75k tweets, seperated in six categories, based on their hashtag: anger, disgust, fear, happiness, neutral, sadness, sarcasm, surprise.

![Python web app](images/React.png?raw=true "Python web app")

It is important not only what user do on website, but also his feeling. Sitecore Analytics OOTB could gather only 'dry' data about users interactions with website. But it doesn't give any information about his feeling. It is possible to get information about users emotions by analything any of texts that he enters on website. It could be feedack, signup newsletter, review and any other forms.

Module comes with sample Feedback forms which shows how text data could be processed to emotions facet into database.
![Controls](images/Controls.png?raw=true "Controls")
![Database](images/Database.png?raw=true "Database")

To show personalization abilities was created simple image banner rendering, which was configured to show different image depending on users feeling. Personalization rule allows to show/hide different content depending on users emotions.
![Personalization](images/Personalization.png?raw=true "Personalization")

### Items location
1. Demo page: `/sitecore/content/Home/Feedback`
2. Content for personalization demo: `/sitecore/content/DemoContent`
3. Layout: `/sitecore/layout/Layouts/Project/Emotion/Demo/Layout`
4. Renderings: `/sitecore/layout/Renderings/Feature/Emotion/Controls`
5. Media items for demo: `/sitecore/media library/Project/Demo`
6. Rules defintion, tag, configuration for Experience Editor: `/sitecore/system/Settings/Rules/Definitions/Elements/Emotion`, `/sitecore/system/Settings/Rules/Definitions/Tags/Emotion`, `/sitecore/system/Settings/Rules/Conditional Renderings/Tags/Emotion`
7. Templates: `/sitecore/templates/Feature/Emotion`


## Video

[Direct link to youtube](https://youtu.be/iSBeSmrN9QA).

[![Sitecore Hackathon 2019: Emotions using xConnect](https://img.youtube.com/vi/iSBeSmrN9QA/0.jpg)](https://youtu.be/iSBeSmrN9QA)
