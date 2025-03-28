function BaseTheme::onAdd(%this)
{
	%this.init();

	%this.emptyBorder = new GuiBorderProfile()
	{
		// Default margin
		margin = 0;
		marginHL = 0;
		marginSL = 0;
		marginNA = 0;
		//Default Border
		border = 0;
		borderHL = 0;
		borderSL = 0;
		borderNA = 0;
		//Default border color
		borderColor   = $color1;
	    borderColorHL = %this.adjustValue($color1, 10);
	    borderColorSL = %this.adjustValue($color1, 10);
	    borderColorNA = %this.setAlpha($color1, 100);
		//Default Padding
		padding = 0;
		paddingHL = 0;
		paddingSL = 0;
		paddingNA = 0;
		//Default underfill
		underfill = true;
	};

	%this.emptyProfile = new GuiControlProfile()
	{
		fillColor = "0 0 0 0";
		fillColorHL = "0 0 0 0";
		fillColorSL = "0 0 0 0";
		fillColorNA = "0 0 0 0";

		fontType = %this.font[1];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize;
		fontColor = %this.color4;
		align = center;
		vAlign = middle;

		borderDefault = %this.emptyBorder;
	};

	%this.makeCursors();
	%this.makeTipProfile();
	%this.makeGeneralProfiles();
	%this.makePanelProfile();
	%this.makeItemSelectProfile();
	%this.makeButtonProfile();
	%this.makeIconButtonProfile();
	%this.makePrimaryButtonProfile();
	%this.makeCheckboxProfile();
	%this.makeTabProfile();
	%this.makeSmallTabProfile();
	%this.makeTextEditProfile();
	%this.makeScrollProfile();
	%this.makeConsoleProfile();
	%this.makeMenuProfile();
	%this.makeDropDownProfile();
	%this.makeWindowProfile();
	%this.makeListBoxProfile();
	%this.makeGraphProfile();
	%this.makeTextDisplayProfile();
	%this.makeSubListProfile();
}

function BaseTheme::init(%this)
{
	%this.name = "Construction Vest";
	//fonts and font sizes
	%this.fontCount = 3;
	%this.font[1] = "raleway";//Most common font
	%this.font[2] = "black ops one";//Title fontType
	%this.font[3] = "fira code semibold";//Code and console font
	%this.fontDirectory = expandPath("^EditorCore/Themes/BaseTheme/Fonts");
	%this.fontSize = 20;

	%this.color1 = "10 10 10 255";//Most commonly used for backgrounds
	%this.color2 = "70 70 70 255";//Normally used for things that stand off the background but are still background
	%this.color3 = "120 120 120 255";//Text set on background
	%this.color4 = "255 255 255 255";//Similar to color 3 but with more contrast
	%this.color5 = "255 133 0 255";//Flavor color that mostly is used on objects during interaction

	%this.borderSize = 3;

	%this.editorBG = "EditorCore:editorBG_BaseTheme";
	%this.fixedHeader200x20 = "EditorCore:fixedHeader200x20_BaseTheme";
	%this.displayBox = "EditorCore:displayBox_BaseTheme";
}

function BaseTheme::makeCursors(%this)
{
	%this.defaultCursor = new GuiCursor()
	{
	    hotSpot = "1 1";
	    renderOffset = "0 0";
	    bitmapName = "^EditorCore/Themes/BaseTheme/images/cursors/defaultCursor.png";
	};

	%this.editCursor = new GuiCursor()
	{
	   hotSpot = "0 0";
	   renderOffset = "0.5 0.5";
	   bitmapName = "^EditorCore/Themes/BaseTheme/images/cursors/ibeam.png";
	};
}

function BaseTheme::makeTipProfile(%this)
{
	%tipBorder = new GuiBorderProfile()
	{
		padding = 4;
		border = 1;
		borderColor = %this.color1;
	};

	%this.tipProfile = new GuiControlProfile()
	{
		fillColor = %this.setAlpha(%this.color3, 240);

		fontType = %this.font[1];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize - 4;
		fontColor = %this.color1;

		borderDefault = %tipBorder;
	};
}

function BaseTheme::makeGeneralProfiles(%this)
{
	//Useful as a background
	%this.overlayProfile = new GuiControlProfile()
	{
		fillColor = %this.setAlpha(%this.color1, 180);

		fontType = %this.font[1];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize - 2;
		fontColor = %this.color4;
	};

	%simpleBorder = new GuiBorderProfile()
	{
		padding = 0;
		border = %this.borderSize;
		borderColor = %this.color5;
	};
	//A simple, well-rounded profile for text or containers
	%this.simpleProfile = new GuiControlProfile()
	{
		fillColor = %this.color1;

		fontType = %this.font[1];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize - 2;
		fontColor = %this.color4;
		align = center;
		vAlign = middle;

		borderDefault = %simpleBorder;
	};

	%simpleBorder2 = new GuiBorderProfile()
	{
		padding = 10;
		border = %this.borderSize;
		borderColor = %this.color5;
	};
	//A simple, well-rounded profile for text or containers
	%this.simpleProfile2 = new GuiControlProfile()
	{
		fillColor = %this.color1;

		fontType = %this.font[1];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize;
		fontColor = %this.color4;
		align = center;
		vAlign = middle;

		borderDefault = %simpleBorder2;
	};

	%infoBorder = new GuiBorderProfile()
	{
		padding = 10;
		border = %this.borderSize;
		borderColor = %this.setAlpha(%this.color4, 30);
	};
	//A simple, well-rounded profile for text or containers
	%this.infoProfile = new GuiControlProfile()
	{
		fillColor = %this.color1;

		fontType = %this.font[3];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize;
		fontColor = %this.color5;
		align = left;
		vAlign = top;

		borderDefault = %infoBorder;
	};

	%this.spriteProfile = new GuiControlProfile()
	{
		fillColor = "0 0 0 0";
		align = center;
		vAlign = middle;

		borderDefault = %this.emptyBorder;
	};

	%displayBorder = new GuiBorderProfile()
	{
		margin = 1;
		marginHL = 0;
		marginSL = 0;
		marginNA = 1;

		padding = 4;
		paddingHL = 5;
		paddingSL = 5;
		paddingNA = 4;
	};
	//A nice container box with all four states
	%this.displayBoxProfile = new GuiControlProfile()
	{
		ImageAsset = "EditorCore:displayBox_BaseTheme";
		fillColor = "0 0 0 0";
		align = center;
		vAlign = middle;

		borderDefault = %displayBorder;
	};
}

function BaseTheme::makePanelProfile(%this)
{
	%panelBorderH = new GuiBorderProfile()
	{
		padding = 10;
		paddingHL = 10;
		paddingSL = 10;
		paddingNA = 10;
	};

	%panelBorderV = new GuiBorderProfile()
	{
		border = 1;
		borderHL = 1;
		borderSL = 1;
		borderNA = 1;

		borderColor = %this.adjustValue(%this.color3, -50);
		borderColorHL = %this.adjustValue(%this.color3, -60);
		borderColorSL = %this.adjustValue(%this.color3, -60);
		borderColorNA = %this.adjustValue(%this.color3, -50);
	};

	%this.panelProfile = new GuiControlProfile()
	{
		fillColor = %this.color2;
		fillColorHL = %this.adjustValue(%this.color2, 5);
		fillColorSL = %this.adjustValue(%this.color2, 5);
		fillColorNA = %this.setAlpha(%this.color2, 80);

		fontType = %this.font[2];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize - 1;
		fontColor = %this.color5;
		fontColorHL = %this.adjustValue(%this.color5, 10);
		fontColorSL = %this.adjustValue(%this.color5, 20);
		fontColorNA = %this.setAlpha(%this.color4, 100);
		align = left;
		vAlign = middle;

		borderDefault = %panelBorderH;
		borderTop = %panelBorderV;
		borderBottom = %panelBorderV;
	};

	//Scrolling panel - a less space demanding scroll bar.
	%this.scrollingPanelTrackProfile = new GuiControlProfile()
	{
		fillColor = %this.color2;
		fillColorHL = %this.color2;
		fillColorSL = %this.color2;
		fillColorNA = %this.setAlpha(%this.color2, 50);
	};

	%thumbBorder = new GuiBorderProfile()
	{
		margin = 3;
		marginHL = 3;
		marginSL = 3;
		paddingNA = 3;
	};

	%this.scrollingPanelThumbProfile = new GuiControlProfile()
	{
		fillColor = %this.color3;
		fillColorHL = %this.adjustValue(%this.color3, 10);
		fillColorSL = %this.color5;
		fillColorNA = %this.setAlpha(%this.color3, 0);

		borderRight = %thumbBorder;
		borderLeft = %thumbBorder;
	};

	%buttonBorder = new GuiBorderProfile()
	{
		padding = 3;
		paddingHL = 3;
		paddingSL = 3;
		paddingNA = 3;
	};

	%this.scrollingPanelArrowProfile = new GuiControlProfile()
	{
		fillColor = %this.color2;
		fillColorHL = %this.color2;
		fillColorSL = %this.color2;
		fillColorNA = %this.setAlpha(%this.color2, 50);

		fontType = %this.font[1];
		fontDirectory = %this.fontDirectory;
		fontColor = %this.color3;
		fontColorHL = %this.adjustValue(%this.color3, 10);
		fontColorSL = %this.color5;
		fontColorNA = %this.setAlpha(%this.color3, 80);

		borderDefault = %buttonBorder;
	};
	%this.scrollingPanelProfile = new GuiControlProfile()
	{
	    fillColor = %this.color1;
	};
}

function BaseTheme::makeItemSelectProfile(%this)
{
	%buttonBorder = new GuiBorderProfile()
	{
		padding = %this.borderSize;
		paddingHL = 0;
		paddingSL = 0;
		paddingNA = %this.borderSize;

		border = 0;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = 0;

		borderColor = "0 0 0 0";
		borderColorHL = %this.setAlpha(%this.adjustValue(%this.color2, 10), 170);
		borderColorSL = %this.setAlpha(%this.adjustValue(%this.color5, 10), 170);
		borderColorNA = "0 0 0 0";

		underfill = false;
	};

	%this.itemSelectProfile = new GuiControlProfile()
	{
		fillColor = %this.color2;
		fillColorHL = %this.adjustValue(%this.color2, 10);
		fillColorSL = %this.color3;
		fillColorNA = %this.setAlpha(%this.color2, 80);

		fontType = %this.font[2];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize;
		fontColor = %this.color4;
		fontColorHL = %this.adjustValue(%this.color4, 10);
		fontColorSL = %this.color1;
		fontColorNA = %this.setAlpha(%this.color4, 100);
		align = Center;

		borderDefault = %buttonBorder;
	};

	%buttonBorder = new GuiBorderProfile()
	{
		padding = 0;
		paddingHL = 0;
		paddingSL = 0;
		paddingNA = 0;

		border = %this.borderSize;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = %this.borderSize;

		borderColor = %this.setAlpha(%this.adjustValue(%this.color5, 10), 170);
		borderColorHL = %this.setAlpha(%this.adjustValue(%this.color5, 15), 170);
		borderColorSL = %this.setAlpha(%this.adjustValue(%this.color5, 10), 130);
		borderColorNA = "0 0 0 0";

		underfill = false;
	};

	%this.itemSelectedProfile = new GuiControlProfile()
	{
		fillColor = %this.color3;
		fillColorHL = %this.adjustValue(%this.color3, 10);
		fillColorSL = %this.color3;
		fillColorNA = %this.setAlpha(%this.color2, 80);

		fontType = %this.font[2];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize;
		fontColor = %this.color4;
		fontColorHL = %this.adjustValue(%this.color4, 10);
		fontColorSL = %this.color1;
		fontColorNA = %this.setAlpha(%this.color4, 100);
		align = Center;

		borderDefault = %buttonBorder;
	};
}

function BaseTheme::makeSubListProfile(%this)
{
	%vBorder = new GuiBorderProfile()
	{
		padding = 1;
		paddingHL = 1;
		paddingSL = 1;
		paddingNA = 1;

		border = 1;
		borderHL = 1;
		borderSL = 1;
		borderNA = 1;

		borderColor = %this.setAlpha(%this.color1, 150);
		borderColorHL = %this.setAlpha(%this.color1, 240);
		borderColorSL = %this.setAlpha(%this.color5, 200);
		borderColorNA = %this.setAlpha(%this.color1, 100);

		underfill = false;
	};

	%hBorder = new GuiBorderProfile()
	{
		padding = 4;
		paddingHL = 4;
		paddingSL = 4;
		paddingNA = 4;

		border = 1;
		borderHL = 1;
		borderSL = 1;
		borderNA = 1;

		borderColor = %this.setAlpha(%this.color1, 150);
		borderColorHL = %this.setAlpha(%this.color1, 240);
		borderColorSL = %this.setAlpha(%this.color5, 200);
		borderColorNA = %this.setAlpha(%this.color1, 100);

		underfill = false;
	};

	%this.subListProfile = new GuiControlProfile()
	{
		fillColor = %this.setAlpha(%this.color1, 100);
		fillColorHL = %this.setAlpha(%this.color1, 200);
		fillColorSL = %this.color5;
		fillColorNA = %this.setAlpha(%this.color1, 10);

		fontType = %this.font[3];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize - 2;
		fontColor = %this.setAlpha(%this.color4, 150);
		fontColorHL = %this.adjustValue(%this.color4, 10);
		fontColorSL = %this.color1;
		fontColorNA = %this.setAlpha(%this.color4, 50);
		align = Center;
		vAlgin = Middle;

		borderDefault = %vBorder;
		borderLeft = %hBorder;
		borderRight = %hBorder;
	};
}

function BaseTheme::makeButtonProfile(%this)
{
	%borderLightH = new GuiBorderProfile()
	{
		padding = 4;
		paddingHL = 4;
		paddingSL = 4;
		paddingNA = 4;

		border = %this.borderSize;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = %this.borderSize;

		borderColor = "255 255 255 80";
		borderColorHL = "255 255 255 80";
		borderColorSL = "0 0 0 80";
		borderColorNA = "255 255 255 80";

		underfill = true;
	};

	%borderLightV = new GuiBorderProfile()
	{
		border = %this.borderSize;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = %this.borderSize;

		borderColor = "255 255 255 80";
		borderColorHL = "255 255 255 80";
		borderColorSL = "0 0 0 80";
		borderColorNA = "255 255 255 80";

		underfill = true;
	};

	%borderDarkH = new GuiBorderProfile()
	{
		padding = 4;
		paddingHL = 4;
		paddingSL = 4;
		paddingNA = 4;

		border = %this.borderSize;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = %this.borderSize;

		borderColor = "0 0 0 80";
		borderColorHL = "0 0 0 80";
		borderColorSL = "255 255 255 80";
		borderColorNA = "0 0 0 80";

		underfill = true;
	};

	%borderDarkV = new GuiBorderProfile()
	{
		border = %this.borderSize;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = %this.borderSize;

		borderColor = "0 0 0 80";
		borderColorHL = "0 0 0 80";
		borderColorSL = "255 255 255 80";
		borderColorNA = "0 0 0 80";

		underfill = true;
	};

	%this.buttonProfile = new GuiControlProfile()
	{
		fillColor = %this.color4;
		fillColorHL = %this.adjustValue(%this.color4, 10);
		fillColorSL = %this.color5;
		fillColorNA = %this.setAlpha(%this.color4, 80);

		fontType = %this.font[2];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize;
		fontColor = %this.color1;
		fontColorHL = %this.adjustValue(%this.color1, 10);
		fontColorSL = %this.color1;
		fontColorNA = %this.setAlpha(%this.color1, 100);
		align = center;
		vAlign = middle;

		borderLeft = %borderLightH;
		borderRight = %borderDarkH;
		borderTop = %borderLightV;
		borderBottom = %borderDarkV;

		canKeyFocus = true;
		tab = true;
	};
}

function BaseTheme::makeIconButtonProfile(%this)
{
	%borderLight = new GuiBorderProfile()
	{
		border = 2;
		borderHL = 2;
		borderSL = 2;
		borderNA = 2;

		borderColor = "255 255 255 80";
		borderColorHL = "255 255 255 80";
		borderColorSL = "0 0 0 80";
		borderColorNA = "255 255 255 40";

		underfill = true;
	};

	%borderDark = new GuiBorderProfile()
	{
		border = 2;
		borderHL = 2;
		borderSL = 2;
		borderNA = 2;

		borderColor = "0 0 0 80";
		borderColorHL = "0 0 0 80";
		borderColorSL = "255 255 255 80";
		borderColorNA = "0 0 0 120";

		underfill = true;
	};

	%this.iconButtonProfile = new GuiControlProfile()
	{
		fillColor = %this.setAlpha(%this.color4, 100);
		fillColorHL = %this.adjustValue(%this.color4, 10);
		fillColorSL = %this.color5;
		fillColorNA = %this.setAlpha(%this.color4, 20);

		fontColor = %this.color1;
		fontColorHL = %this.adjustValue(%this.color1, 10);
		fontColorSL = %this.color1;
		fontColorNA = %this.setAlpha(%this.color1, 100);
		align = center;
		vAlign = middle;

		borderLeft = %borderLight;
		borderRight = %borderDark;
		borderTop = %borderLight;
		borderBottom = %borderDark;

		canKeyFocus = true;
		tab = true;
	};
}

function BaseTheme::makePrimaryButtonProfile(%this)
{
	%borderLightH = new GuiBorderProfile()
	{
		padding = 4;
		paddingHL = 4;
		paddingSL = 4;
		paddingNA = 4;

		border = %this.borderSize;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = %this.borderSize;

		borderColor = "255 255 255 80";
		borderColorHL = "255 255 255 80";
		borderColorSL = "0 0 0 80";
		borderColorNA = "255 255 255 80";

		underfill = true;
	};

	%borderLightV = new GuiBorderProfile()
	{
		border = %this.borderSize;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = %this.borderSize;

		borderColor = "255 255 255 80";
		borderColorHL = "255 255 255 80";
		borderColorSL = "0 0 0 80";
		borderColorNA = "255 255 255 80";

		underfill = true;
	};

	%borderDarkH = new GuiBorderProfile()
	{
		padding = 4;
		paddingHL = 4;
		paddingSL = 4;
		paddingNA = 4;

		border = %this.borderSize;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = %this.borderSize;

		borderColor = "0 0 0 80";
		borderColorHL = "0 0 0 80";
		borderColorSL = "255 255 255 80";
		borderColorNA = "0 0 0 80";

		underfill = true;
	};

	%borderDarkV = new GuiBorderProfile()
	{
		border = %this.borderSize;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = %this.borderSize;

		borderColor = "0 0 0 80";
		borderColorHL = "0 0 0 80";
		borderColorSL = "255 255 255 80";
		borderColorNA = "0 0 0 80";

		underfill = true;
	};

	%this.primaryButtonProfile = new GuiControlProfile()
	{
		fillColor = %this.color5;
		fillColorHL = %this.adjustValue(%this.color5, 10);
		fillColorSL = %this.adjustValue(%this.color5, 15);
		fillColorNA = %this.setAlpha(%this.color5, 80);

		fontType = %this.font[2];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize + 1;
		fontColor = %this.color1;
		fontColorHL = %this.adjustValue(%this.color1, 10);
		fontColorSL = %this.color1;
		fontColorNA = %this.setAlpha(%this.color1, 100);
		align = center;
		vAlign = middle;

		borderLeft = %borderLightH;
		borderRight = %borderDarkH;
		borderTop = %borderLightV;
		borderBottom = %borderDarkV;

		canKeyFocus = true;
		tab = true;
	};
}

function BaseTheme::makeCheckboxProfile(%this)
{
	%borderLight = new GuiBorderProfile()
	{
		border = %this.borderSize;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = %this.borderSize;

		borderColor = "255 255 255 80";
		borderColorHL = "255 255 255 80";
		borderColorSL = "0 0 0 80";
		borderColorNA = "255 255 255 0";

		underfill = true;
	};

	%borderDark = new GuiBorderProfile()
	{
		border = %this.borderSize;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = %this.borderSize;

		borderColor = "0 0 0 80";
		borderColorHL = "0 0 0 80";
		borderColorSL = "255 255 255 80";
		borderColorNA = "0 0 0 0";

		underfill = true;
	};

	%this.checkboxProfile = new GuiControlProfile()
	{
		fillColor = %this.color4;
		fillColorHL = %this.adjustValue(%this.color4, 10);
		fillColorSL = %this.color5;
		fillColorNA = %this.setAlpha(%this.color4, 80);

		fontType = %this.font[2];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize;
		fontColor = %this.color4;
		fontColorHL = %this.color5;
		fontColorSL = %this.color4;
		fontColorNA = %this.setAlpha(%this.color4, 100);
		align = left;
		vAlign = middle;

		borderLeft = %borderLight;
		borderRight = %borderDark;
		borderTop = %borderLight;
		borderBottom = %borderDark;

		canKeyFocus = true;
		tab = true;
	};
}

function BaseTheme::makeTabProfile(%this)
{
	%tabBorderTop = new GuiBorderProfile()
	{
		margin = 2;
		marginHL = 1;
		marginSL = 0;
		marginNA = 2;

		border = 2;
		borderHL = 2;
		borderSL = 2;
		borderNA = 2;

		padding = 3;
		paddingHL = 4;
		paddingSL = 5;
		paddingNA = 3;

		borderColor = "255 255 255 90";
		borderColorHL = "255 255 255 90";
		borderColorSL = "255 255 255 90";
		borderColorNA = "255 255 255 90";
	};

	%tabBorderTopAlt = new GuiBorderProfile()
	{
		margin = 2;
		marginHL = 1;
		marginSL = 0;
		marginNA = 2;

		border = 2;
		borderHL = 2;
		borderSL = 2;
		borderNA = 2;

		padding = 3;
		paddingHL = 4;
		paddingSL = 5;
		paddingNA = 3;

		borderColor = "0 0 0 90";
		borderColorHL = "0 0 0 90";
		borderColorSL = "0 0 0 90";
		borderColorNA = "0 0 0 90";
	};

	%tabBorderLeft = new GuiBorderProfile()
	{
		margin = 2;
		marginHL = 2;
		marginSL = 2;
		marginNA = 2;

		border = 2;
		borderHL = 2;
		borderSL = 2;
		borderNA = 2;

		padding = 10;
		paddingHL = 10;
		paddingSL = 10;
		paddingNA = 10;

		borderColor = "255 255 255 90";
		borderColorHL = "255 255 255 90";
		borderColorSL = "255 255 255 90";
		borderColorNA = "255 255 255 90";
	};

	%tabBorderRight = new GuiBorderProfile()
	{
		margin = 2;
		marginHL = 2;
		marginSL = 2;
		marginNA = 2;

		border = 2;
		borderHL = 2;
		borderSL = 2;
		borderNA = 2;

		padding = 10;
		paddingHL = 10;
		paddingSL = 10;
		paddingNA = 10;

		borderColor = "0 0 0 90";
		borderColorHL = "0 0 0 90";
		borderColorSL = "0 0 0 90";
		borderColorNA = "0 0 0 90";
	};

	%tabBorderBottom = new GuiBorderProfile()
	{
		padding = 5;
		paddingHL = 5;
		paddingSL = 5;
		paddingNA = 5;
	};

	%this.tabProfileTop = new GuiControlProfile ()
	{
		fillColor = %this.color3;
		fillColorHL = %this.adjustValue(%this.color3, 10);
		fillColorSL = %this.color5;
		fillColorNA = %this.setAlpha(%this.color3, 150);

		fontType = %this.font[2];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize;
		fontColor = %this.color4;
		fontColorHL = %this.adjustValue(%this.color4, 10);
		fontColorSL = %this.color1;
		fontColorNA = %this.setAlpha(%this.color4, 100);
		align = Center;
		vAlign = Middle;

		borderTop = %tabBorderTop;
		borderLeft = %tabBorderLeft;
		borderRight = %tabBorderRight;
		borderBottom = %tabBorderBottom;
	};

	%this.tabProfileBottom = new GuiControlProfile ()
	{
		fillColor = %this.color3;
		fillColorHL = %this.adjustValue(%this.color3, 10);
		fillColorSL = %this.color5;
		fillColorNA = %this.setAlpha(%this.color3, 150);

		fontType = %this.font[2];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize;
		fontColor = %this.color4;
		fontColorHL = %this.adjustValue(%this.color4, 10);
		fontColorSL = %this.color1;
		fontColorNA = %this.setAlpha(%this.color4, 100);
		align = Center;

		borderTop = %tabBorderBottom;
		borderLeft = %tabBorderLeft;
		borderRight = %tabBorderRight;
		borderBottom = %tabBorderTopAlt;
	};

	%this.tabProfileLeft = new GuiControlProfile ()
	{
		fillColor = %this.color3;
		fillColorHL = %this.adjustValue(%this.color3, 10);
		fillColorSL = %this.color5;
		fillColorNA = %this.setAlpha(%this.color3, 150);

		fontType = %this.font[2];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize;
		fontColor = %this.color4;
		fontColorHL = %this.adjustValue(%this.color4, 10);
		fontColorSL = %this.color1;
		fontColorNA = %this.setAlpha(%this.color4, 100);
		align = Center;

		borderTop = %tabBorderLeft;
		borderLeft = %tabBorderTop;
		borderRight = %tabBorderBottom;
		borderBottom = %tabBorderRight;
	};

	%this.tabProfileRight = new GuiControlProfile ()
	{
		fillColor = %this.color3;
		fillColorHL = %this.adjustValue(%this.color3, 10);
		fillColorSL = %this.color5;
		fillColorNA = %this.setAlpha(%this.color3, 150);

		fontType = %this.font[2];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize;
		fontColor = %this.color4;
		fontColorHL = %this.adjustValue(%this.color4, 10);
		fontColorSL = %this.color1;
		fontColorNA = %this.setAlpha(%this.color4, 100);
		align = Center;

		borderTop = %tabBorderLeft;
		borderLeft = %tabBorderBottom;
		borderRight = %tabBorderTopAlt;
		borderBottom = %tabBorderRight;
	};

	%bookBorderBottom = new GuiBorderProfile()
	{
		margin = 0;
		border = %this.borderSize;
		borderColor = "0 0 0 150";
		padding = 0;
	};

	%bookBorderDefault = new GuiBorderProfile()
	{
		padding = 5;
	};

	%this.tabBookProfileTop = new GuiControlProfile ()
	{
		borderDefault = %bookBorderDefault;
		borderBottom = %bookBorderBottom;
		fillcolor = %this.color2;
	};

	%this.tabBookProfileBottom = new GuiControlProfile ()
	{
		borderDefault = %bookBorderDefault;
		borderTop = %bookBorderBottom;
		fillcolor = %this.color2;
	};

	%this.tabBookProfileLeft = new GuiControlProfile ()
	{
		borderDefault = %bookBorderDefault;
		borderRight = %bookBorderBottom;
		fillcolor = %this.color2;
	};

	%this.tabBookProfileRight = new GuiControlProfile ()
	{
		borderDefault = %bookBorderDefault;
		borderLeft = %bookBorderBottom;
		fillcolor = %this.color2;
	};

	%this.tabPageProfile = new GuiControlProfile ()
	{
	    fillColor = %this.setAlpha(%this.color1, 150);
	};
}

function BaseTheme::makeSmallTabProfile(%this)
{
	%tabBorder = new GuiBorderProfile()
	{
		margin = 1;
		marginHL = 1;
		marginSL = 0;
		marginNA = 1;

		border = 1;
		borderHL = 1;
		borderSL = 1;
		borderNA = 1;

		padding = 2;
		paddingHL = 2;
		paddingSL = 3;
		paddingNA = 2;

		borderColor = "0 0 0 90";
		borderColorHL = "0 0 0 90";
		borderColorSL = "255 255 255 90";
		borderColorNA = "0 0 0 90";
	};

	%this.smallTabProfile = new GuiControlProfile ()
	{
		fillColor = %this.color3;
		fillColorHL = %this.adjustValue(%this.color3, 10);
		fillColorSL = %this.color5;
		fillColorNA = %this.setAlpha(%this.color3, 150);

		fontType = %this.font[3];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize - 2;
		fontColor = %this.color4;
		fontColorHL = %this.adjustValue(%this.color4, 10);
		fontColorSL = %this.color1;
		fontColorNA = %this.setAlpha(%this.color4, 100);
		align = Center;

		borderDefault = %tabBorder;
	};
	%bookBorderDefault = new GuiBorderProfile()
	{
		padding = 0;
		border = 1;
		borderColor = "0 0 0 50";
	};
	%this.smallTabBookProfile = new GuiControlProfile ()
	{
		borderDefault = %bookBorderDefault;
		fillcolor = %this.adjustValue(%this.color2, -10);
	};
}

function BaseTheme::makeTextEditProfile(%this)
{
	%labelBorder = new GuiBorderProfile()
	{
		padding = 2;
	};
	%this.labelProfile = new GuiControlProfile()
	{
		fillColor = "0 0 0 0";

		fontType = %this.font[2];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize - 2;
		fontColor = %this.color4;
		align = "left";
		vAlign = "top";

		borderDefault = %labelBorder;
	};

	%textBorderV = new GuiBorderProfile()
	{
		padding = 2;
		paddingHL = 2;
		paddingSL = 2;
		paddingNA = 2;

		border = %this.borderSize;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = %this.borderSize;

		borderColor = %this.color3;
		borderColorHL = %this.adjustValue(%this.color5, 10);
		borderColorSL = %this.color5;
		borderColorNA = %this.setAlpha(%this.color3, 100);
	};

	%textBorderH = new GuiBorderProfile()
	{
		padding = 10;
		paddingHL = 10;
		paddingSL = 10;
		paddingNA = 10;

		border = %this.borderSize;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = %this.borderSize;

		borderColor = %this.color3;
		borderColorHL = %this.adjustValue(%this.color5, 10);
		borderColorSL = %this.color5;
		borderColorNA = %this.setAlpha(%this.color3, 100);
	};

	%this.textEditProfile = new GuiControlProfile()
	{
		fillColor = %this.color4;
		fillColorHL = %this.adjustValue(%this.color4, 10);
		fillColorSL = %this.color4;
		fillColorNA = %this.setAlpha(%this.color4, 80);
		fillColorTextSL = %this.color5;

		fontType = %this.font[3];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize;
		fontColor = %this.setAlpha(%this.color1, 220);
		fontColorHL = %this.adjustValue(%this.color1, 10);
		fontColorSL = %this.color1;
		fontColorNA = %this.setAlpha(%this.color1, 100);
		fontColorTextSL = %this.color1;
		align = left;
		vAlign = middle;
		cursorColor = %this.color2;

		borderDefault = %textBorderV;
		borderRight = %textBorderH;
		borderLeft = %textBorderH;

		tab = true;
		canKeyFocus = true;
		returnTab = true;
	};
}

function BaseTheme::makeScrollProfile(%this)
{
	%trackBorder = new GuiBorderProfile()
	{
		margin = 0;
		padding = 0;
		border = 0;
	};

	%this.trackProfile = new GuiControlProfile()
	{
			fillColor = %this.setAlpha(%this.color2, 150);
			fillColorHL = %this.setAlpha(%this.color2, 150);
			fillColorSL = %this.setAlpha(%this.adjustValue(%this.color2, 10), 150);
			fillColorNA = %this.setAlpha(%this.color2, 50);
			borderDefault = %trackBorder;
	};

	%buttonBorderLT = new GuiBorderProfile()
	{
		padding = 3;
		paddingHL = 2;
		paddingSL = 2;
		paddingNA = 3;

		border = 1;
		borderHL = 2;
		borderSL = 2;
		borderNA = 1;

		borderColor = %this.adjustValue(%this.color3, 20);
		borderColorHL = %this.adjustValue(%this.color3, 30);
		borderColorSL = %this.adjustValue(%this.color5, 20);
		borderColorNA = %this.setAlpha(%this.adjustValue(%this.color3, 20), 80);

		underfill = true;
	};

	%buttonBorderRB = new GuiBorderProfile()
	{
		padding = 3;
		paddingHL = 2;
		paddingSL = 2;
		paddingNA = 3;

		border = 1;
		borderHL = 2;
		borderSL = 2;
		borderNA = 1;

		borderColor = %this.adjustValue(%this.color3, -20);
		borderColorHL = %this.adjustValue(%this.color3, -10);
		borderColorSL = %this.adjustValue(%this.color5, -20);
		borderColorNA = %this.setAlpha(%this.adjustValue(%this.color3, -20), 80);

		underfill = true;
	};

	%this.thumbProfile = new GuiControlProfile()
	{
		fillColor = %this.color3;
		fillColorHL = %this.adjustValue(%this.color3, 10);
		fillColorSL = %this.color5;
		fillColorNA = %this.setAlpha(%this.color3, 80);

		borderDefault = %buttonBorderLT;
		borderRight = %buttonBorderRB;
		borderBottom = %buttonBorderRB;
	};

	%this.scrollArrowProfile = new GuiControlProfile()
	{
		fillColor = %this.color3;
		fillColorHL = %this.adjustValue(%this.color3, 10);
		fillColorSL = %this.color5;
		fillColorNA = %this.setAlpha(%this.color3, 80);

		fontType = %this.font[1];
		fontDirectory = %this.fontDirectory;
		fontColor = %this.color2;
		fontColorHL = %this.color2;
		fontColorSL = %this.color4;
		fontColorNA = %this.setAlpha(%this.color2, 80);

		borderDefault = %buttonBorderLT;
		borderRight = %buttonBorderRB;
		borderBottom = %buttonBorderRB;
	};

	%mainBorder = new GuiBorderProfile()
	{
		margin = 5;
		padding = 5;
		border = 3;
		borderColor = %this.color5;
	};
	%this.scrollProfile = new GuiControlProfile()
	{
	    fillColor = %this.setAlpha(%this.color2, 180);
		borderDefault = %mainBorder;
	};

	//Tiny scroll profile - for uses when you have little space
	%this.tinyTrackProfile = new GuiControlProfile()
	{
			fillColor = %this.setAlpha(%this.color2, 150);
			fillColorHL = %this.setAlpha(%this.color2, 150);
			fillColorSL = %this.setAlpha(%this.adjustValue(%this.color2, 10), 150);
			fillColorNA = %this.setAlpha(%this.color2, 50);
			borderDefault = %this.emptyBorder;
	};

	%this.tinyThumbProfile = new GuiControlProfile()
	{
		fillColor = %this.color3;
		fillColorHL = %this.adjustValue(%this.color3, 10);
		fillColorSL = %this.color5;
		fillColorNA = %this.setAlpha(%this.color3, 80);
		borderDefault = %this.emptyBorder;
	};

	//probably best to avoid the arrow buttons for very small scroll bars
	%this.tinyScrollArrowProfile = new GuiControlProfile()
	{
		fillColor = %this.color3;
		fillColorHL = %this.adjustValue(%this.color3, 10);
		fillColorSL = %this.color5;
		fillColorNA = %this.setAlpha(%this.color3, 80);

		fontType = %this.font[1];
		fontDirectory = %this.fontDirectory;
		fontColor = %this.color2;
		fontColorHL = %this.color2;
		fontColorSL = %this.color4;
		fontColorNA = %this.setAlpha(%this.color2, 80);
		borderDefault = %this.emptyBorder;
	};
	%this.tinyScrollProfile = new GuiControlProfile()
	{
	    fillColor = %this.setAlpha(%this.color2, 180);
		borderDefault = %this.emptyBorder;
	};
}

function BaseTheme::makeConsoleProfile(%this)
{
	%this.consoleProfile = new GuiControlProfile()
	{
		fontType = %this.font[3];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize + 2;
		fontColor = %this.color4; //Normal text
		fontColorHL = %this.setAlpha(%this.color4, 140); //Warnings
		fontColorNA = "255 0 0 255"; //Errors
	};
}

function BaseTheme::makeMenuProfile(%this)
{
	%menuBarBorder = new GuiBorderProfile()
	{
		padding = 2;
	};

	%this.menuBarProfile = new GuiControlProfile()
	{
		fillColor = %this.adjustValue(%this.color1, -7);
		canKeyFocus = true;
		borderDefault = %menuBarBorder;
	};

	%menuBorder = new GuiBorderProfile()
	{
		margin = 2;
		marginHL = 0;
		marginSL = 0;
		marginNA = 2;

		border = 0;
		borderHL = 2;
		borderSL = 2;
		borderNA = 0;

		borderColorHL = "255 255 255 30";
		borderColorSL = %this.color5;
	};

	%menuBottomBorder = new GuiBorderProfile()
	{
		paddingSL = 2;

		margin = 2;
		marginHL = 0;
		marginSL = 0;
		marginNA = 2;

		border = 0;
		borderHL = 2;
		borderSL = 2;
		borderNA = 0;

		borderColorHL = "255 255 255 30";
		borderColorSL = %this.color5;
	};

	%menuSideBorder = new GuiBorderProfile()
	{
		border = 0;
		borderHL = 2;
		borderSL = 2;
		borderNA = 0;

		padding = 10;
		paddingHL = 8;
		paddingSL = 8;
		paddingNA = 10;

		borderColorHL = "255 255 255 30";
		borderColorSL = %this.color5;
	};

	%this.menuProfile = new GuiControlProfile()
	{
		fillColor = "0 0 0 0";
		fillColorHL = "255 255 255 10";
		fillColorSL = %this.adjustValue(%this.color5, -15);
		fillColorNA = "0 0 0 0";

		borderDefault = %menuBorder;
		borderLeft = %menuSideBorder;
		borderRight = %menuSideBorder;
		borderBottom = %menuBottomBorder;

		fontType = %this.font[3];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize;

		fontColor = %this.color4;
		fontColorHL = %this.adjustValue(%this.color4, 10);
		fontColorSL = %this.color4;
		fontColorNA = %this.adjustValue(%this.color4, 100);

		canKeyFocus = true;
	};

	%menuContentVertBorder = new GuiBorderProfile()
	{
		border = 2;
		padding = 4;
		borderColor = %this.color5;
	};

	%menuContentSideBorder = new GuiBorderProfile()
	{
		border = 2;
		padding = 0;
		borderColor = %this.color5;
	};

	%this.menuContentProfile = new GuiControlProfile()
	{
		fillColor = %this.adjustValue(%this.color1, -5);

		borderDefault = %menuContentSideBorder;
		borderTop = %menuContentVertBorder;
		borderBottom = %menuContentVertBorder;
	};

	%menuItemBorderTop = new GuiBorderProfile()
	{
		padding = 6;
		paddingHL = 6;
		paddingSL = 0;
		paddingNA = 6;

		marginSL = 4;
		borderSL = 1;
		borderColorSL = "0 0 0 50";
	};

	%menuItemBorderBottom = new GuiBorderProfile()
	{
		padding = 6;
		paddingHL = 6;
		paddingSL = 0;
		paddingNA = 6;

		marginSL = 4;
		borderSL = 1;
		borderColorSL = "255 255 255 50";
	};

	%menuItemBorderSide = new GuiBorderProfile()
	{
		padding = 6;
		paddingHL = 6;
		paddingSL = 0;
		paddingNA = 6;

		marginSL = 0;
		borderSL = 0;
		paddingSL = 6;
	};

	%this.menuItemProfile = new GuiControlProfile()
	{
		fillColor = %this.adjustValue(%this.color1, -5);
		fillColorHL = %this.adjustValue(%this.color5, -15);
		fillColorNA = %this.color1;
		align = left;

		tab = false;
		canKeyFocus = true;

		fontType = %this.font[3];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize;

		fontColor = %this.color4;
		fontColorHL = %this.adjustValue(%this.color4, 10);
		fontColorNA = %this.setAlpha(%this.color4, 150);

		borderDefault = %menuItemBorderSide;
		borderTop = %menuItemBorderTop;
		borderBottom = %menuItemBorderBottom;
	};
}

function BaseTheme::makeDropDownProfile(%this)
{
	%borderLightH = new GuiBorderProfile()
	{
		padding = 4;
		paddingHL = 4;
		paddingSL = 4;
		paddingNA = 4;

		border = %this.borderSize;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = %this.borderSize;

		borderColor = "255 255 255 80";
		borderColorHL = "255 255 255 80";
		borderColorSL = "0 0 0 80";
		borderColorNA = "255 255 255 80";

		underfill = true;
	};

	%borderLightV = new GuiBorderProfile()
	{
		border = %this.borderSize;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = %this.borderSize;

		borderColor = "255 255 255 80";
		borderColorHL = "255 255 255 80";
		borderColorSL = "0 0 0 80";
		borderColorNA = "255 255 255 80";

		underfill = true;
	};

	%borderDarkH = new GuiBorderProfile()
	{
		padding = 4;
		paddingHL = 4;
		paddingSL = 4;
		paddingNA = 4;

		border = %this.borderSize;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = %this.borderSize;

		borderColor = "0 0 0 80";
		borderColorHL = "0 0 0 80";
		borderColorSL = "255 255 255 80";
		borderColorNA = "0 0 0 80";

		underfill = true;
	};

	%borderDarkV = new GuiBorderProfile()
	{
		border = %this.borderSize;
		borderHL = %this.borderSize;
		borderSL = %this.borderSize;
		borderNA = %this.borderSize;

		borderColor = "0 0 0 80";
		borderColorHL = "0 0 0 80";
		borderColorSL = "255 255 255 80";
		borderColorNA = "0 0 0 80";

		underfill = true;
	};

	%this.DropDownProfile = new GuiControlProfile()
	{
		fillColor = %this.color4;
		fillColorHL = %this.adjustValue(%this.color4, 10);
		fillColorSL = %this.color5;
		fillColorNA = %this.setAlpha(%this.color4, 80);

		fontType = %this.font[3];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize;
		fontColor = %this.color1;
		fontColorHL = %this.adjustValue(%this.color1, 10);
		fontColorSL = %this.color1;
		fontColorNA = %this.setAlpha(%this.color1, 100);
		align = left;
		vAlign = middle;

		borderLeft = %borderLightH;
		borderRight = %borderDarkH;
		borderTop = %borderLightV;
		borderBottom = %borderDarkV;

		canKeyFocus = true;
		tab = true;
	};

	%borderItem = new GuiBorderProfile()
	{
		margin = 1;
		marginHL = 1;
		marginSL = 0;
		marginNA = 1;

		padding = 3;
		paddingHL = 3;
		paddingSL = 4;
		paddingNA = 3;

		border = 1;
		borderHL = 1;
		borderSL = 1;
		borderNA = 1;

		borderColor = %this.setAlpha(%this.color4, 80);
		borderColorHL = %this.setAlpha(%this.color4, 80);
		borderColorSL = %this.setAlpha(%this.color4, 150);
		borderColorNA = %this.setAlpha(%this.color4, 40);

		underfill = true;
	};

	%this.DropDownItemProfile = new GuiControlProfile()
	{
		fillColor = %this.color1;
	    fillColorHL = %this.adjustValue(%this.color1, 10);
	    fillColorSL = %this.color5;
	    fillColorNA = %this.setAlpha(%this.color1, 100);

		fontType = %this.font[3];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize;
		fontColor = %this.color4;
		fontColorHL = %this.adjustValue(%this.color4, 10);
		fontColorSL = %this.color1;
		fontColorNA = %this.setAlpha(%this.color4, 100);
		align = left;
		vAlign = middle;

		borderDefault = %borderItem;

		tab = false;
		canKeyFocus = true;
	};
}

function BaseTheme::makeWindowProfile(%this)
{
	%windowBorderL = new GuiBorderProfile()
	{
		padding = 10;
		paddingHL = 10;
		paddingSL = 10;
		paddingNA = 4;

		border = 1;
		borderHL = 1;
		borderSL = 1;
		borderNA = 1;

		borderColor = %this.adjustValue(%this.color3, -50);
		borderColorHL = %this.adjustValue(%this.color3, -60);
		borderColorSL = %this.adjustValue(%this.color3, -60);
		borderColorNA = %this.adjustValue(%this.color3, -50);
	};

	%windowBorderR = new GuiBorderProfile()
	{
		border = 1;
		borderHL = 1;
		borderSL = 1;
		borderNA = 1;

		borderColor = %this.adjustValue(%this.color3, -50);
		borderColorHL = %this.adjustValue(%this.color3, -60);
		borderColorSL = %this.adjustValue(%this.color3, -60);
		borderColorNA = %this.adjustValue(%this.color3, -50);
	};

	%windowBorderV = new GuiBorderProfile()
	{
		border = 1;
		borderHL = 1;
		borderSL = 1;
		borderNA = 1;

		borderColor = %this.adjustValue(%this.color3, -50);
		borderColorHL = %this.adjustValue(%this.color3, -60);
		borderColorSL = %this.adjustValue(%this.color3, -60);
		borderColorNA = %this.adjustValue(%this.color3, -50);
	};

	%this.windowProfile = new GuiControlProfile()
	{
		fillColor = %this.color2;
		fillColorHL = %this.adjustValue(%this.color2, 1);
		fillColorSL = %this.adjustValue(%this.color2, 5);
		fillColorNA = %this.color2;

		fontType = %this.font[2];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize - 1;
		fontColor = %this.color5;
		fontColorHL = %this.adjustValue(%this.color5, 2);
		fontColorSL = %this.adjustValue(%this.color5, 4);
		fontColorNA = %this.color5;
		align = left;
		vAlign = middle;

		borderLeft = %windowBorderL;
		borderRight = %windowBorderR;
		borderTop = %windowBorderV;
		borderBottom = %windowBorderV;
	};

	%windowContentBorder = new GuiBorderProfile()
	{
		border = 3;
		borderHL = 3;
		borderSL = 3;
		borderNA = 3;

		borderColor = %this.adjustValue(%this.color3, -50);
		borderColorHL = %this.adjustValue(%this.color3, -60);
		borderColorSL = %this.adjustValue(%this.color3, -60);
		borderColorNA = %this.adjustValue(%this.color3, -50);

		padding = 1;
		paddingHL = 1;
		paddingSL = 1;
		paddingNA = 1;
	};

	%this.windowContentProfile = new GuiControlProfile()
	{
		fillColor = %this.color1;
		fillColorSL = %this.adjustValue(%this.color1, 5);

		borderLeft = %windowContentBorder;
		borderRight = %windowContentBorder;
		borderTop = %this.emptyBorder;
		borderBottom = %windowContentBorder;
	};

	%windowButtonBorder = new GuiBorderProfile()
	{
		margin = 3;
		marginHL = 3;
		marginSL = 3;
		marginNA = 3;

		padding = 3;
		paddingHL = 3;
		paddingSL = 3;
		paddingNA = 3;
	};

	%this.windowButtonProfile = new GuiControlProfile()
	{
		fillColor = %this.color3;
		fillColorHL = %this.adjustValue(%this.color3, 10);
		fillColorSL = %this.color5;
		fillColorNA = %this.color3;

		fontColor = %this.color1;
		fontColorHL = %this.color1;
		fontColorSL = %this.color1;
		fontColorNA = %this.color1;

		borderDefault = %windowButtonBorder;
	};
}

function BaseTheme::makeListBoxProfile(%this)
{
	%borderProfile = new GuiBorderProfile()
	{
		margin = 1;
		marginHL = 1;
		marginSL = 1;
		marginNA = 1;

		padding = 4;
		paddingHL = 4;
		paddingSL = 4;
		paddingNA = 4;
	};

	%this.listBoxProfile = new GuiControlProfile ()
	{
	    // fill color
	    fillColor = %this.adjustValue(%this.color1, 2);
	    fillColorHL = %this.adjustValue(%this.color1, 4);
	    fillColorSL = %this.color5;
	    fillColorNA = %this.setAlpha(%this.color1, 150);
		align = left;

		tab = false;
		canKeyFocus = true;

		fontType = %this.font[3];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize;
		fontColor = %this.color4;
		fontColorHL = %this.adjustValue(%this.color4, 20);
		fontColorSL = %this.adjustValue(%this.color1, 2);
		fontColorNA = %this.adjustValue(%this.color4, -30);

		borderDefault = %borderProfile;
	};
}

function BaseTheme::makeGraphProfile(%this)
{
	%border = new GuiBorderProfile()
	{
		padding = 4;
		border = %this.borderSize;
		borderColor = %this.color3; //Used for the border as normal
	};

	%this.graphProfile = new GuiControlProfile()
	{
		fillColor = %this.color2; //Used for the background of the control as normal
		fillColorHL = %this.setAlpha(%this.color3, 220); //Used for the grid and labels
		fillColorSL = %this.color5; //Used for the lines of the control
		fillColorNA = %this.setAlpha(%this.color5, 100); //Used for the variance when it is displayed

		fontType = %this.font[3];
		fontDirectory = %this.fontDirectory;
		fontSize = %this.fontSize - 2;
		fontColor = %this.color4; //Used for the points
		fontColorHL = %this.adjustValue(%this.color4, 10); //Used for the points when they are hovered over
		fontColorSL = %this.adjustValue(%this.color5, 10); //Used for the selected points

		borderDefault = %border;
	};
}

function BaseTheme::makeTextDisplayProfile(%this)
{
	%border = new GuiBorderProfile()
	{
		padding = 5;
	};

	%this.titleProfile = new GuiControlProfile()
	{
		fillColor = "0 0 0 0";
		fillColorHL = "0 0 0 0";
		fillColorSL = "0 0 0 0";
		fillColorNA = "0 0 0 0";

		fontType = %this.font[2];
		fontDirectory = %this.fontDirectory;
		fontSize = 28;
		fontColor = %this.adjustValue(%this.color4, 10);
		align = "left";
		vAlign = "top";

		borderDefault = %border;
		borderTop = %this.emptyBorder;
		borderBottom = %this.emptyBorder;
	};

	%this.codeProfile = new GuiControlProfile()
	{
		fillColor = "0 0 0 0";
		fillColorHL = "0 0 0 0";
		fillColorSL = "0 0 0 0";
		fillColorNA = "0 0 0 0";

		fontType = %this.font[3];
		fontDirectory = %this.fontDirectory;
		fontSize = 18;
		fontColor = %this.adjustValue(%this.color2, 10);
		align = "left";
		vAlign = "top";

		borderDefault = %border;
		borderTop = %this.emptyBorder;
		borderBottom = %this.emptyBorder;
	};

	%this.normalTextProfile = new GuiControlProfile()
	{
		fillColor = "0 0 0 0";
		fillColorHL = "0 0 0 0";
		fillColorSL = "0 0 0 0";
		fillColorNA = "0 0 0 0";

		fontType = %this.font[1];
		fontDirectory = %this.fontDirectory;
		fontSize = 20;
		fontColor = %this.adjustValue(%this.color3, 10);
		align = "left";
		vAlign = "top";

		borderDefault = %border;
		borderTop = %this.emptyBorder;
		borderBottom = %this.emptyBorder;
	};

	%spacerBorder = new GuiBorderProfile()
	{
		margin = 3;
	};

	%this.spacerProfile = new GuiControlProfile()
	{
		fillColor = %this.color5;
		fontType = %this.font[1];
		fontDirectory = %this.fontDirectory;
		fontSize = 14;
		fontColor = %this.color1;
		align = "center";
		vAlign = "middle";

		borderDefault = %this.emptyBorder;
		borderLeft = %spacerBorder;
		borderRight = %spacerBorder;
		borderBottom = %spacerBorder;
	};
}

//Positive values are brighter, negative are darker
function BaseTheme::adjustValue(%this, %color, %percent)
{
	%red = getWord(%color, 0);
	%green = getWord(%color, 1);
	%blue = getWord(%color, 2);
	%alpha = getWord(%color, 3);

	%largest = mGetMax(%red, mGetMax(%blue, %green));
	%currentValue = %largest / 255;
	%fullRed = %red / %currentValue;
	%fullGreen = %green / %currentValue;
	%fullBlue = %blue / %currentValue;

	%newValue = %currentValue += (%percent/100);
	%newValue = mClamp(%newValue, 0, 100);
	%newColor = mRound(mClamp((%fullRed * %newValue), 0, 255)) SPC
		mRound(mClamp((%fullGreen * %newValue), 0, 255)) SPC
		mRound(mClamp((%fullBlue * %newValue), 0, 255)) SPC %alpha;

	return %newColor;
}

function BaseTheme::setAlpha(%this, %color, %newAlpha)
{
	%red = getWord(%color, 0);
	%green = getWord(%color, 1);
	%blue = getWord(%color, 2);
	return %red SPC %green SPC %blue SPC mRound(mClamp(%newAlpha, 0, 255));
}
