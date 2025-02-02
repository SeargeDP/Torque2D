//-----------------------------------------------------------------------------
// Copyright (c) 2013 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------
#include "gui/editor/guiInspectorTypes.h"

//////////////////////////////////////////////////////////////////////////
// GuiInspectorTypeEnum 
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypeEnum);

GuiControl* GuiInspectorTypeEnum::constructEditControl(S32 width)
{
	GuiDropDownCtrl* retCtrl = new GuiDropDownCtrl();

   // If we couldn't construct the control, bail!
   if( retCtrl == NULL )
      return retCtrl;

   // Let's make it look pretty.
   retCtrl->setControlProfile(mGroup->mInspector->mDropDownProfile);
   retCtrl->setControlListBoxProfile(mGroup->mInspector->mDropDownItemProfile);
   retCtrl->setControlScrollProfile(mGroup->mInspector->mScrollProfile);
   retCtrl->setControlThumbProfile(mGroup->mInspector->mThumbProfile);
   retCtrl->setControlArrowProfile(mGroup->mInspector->mArrowProfile);
   retCtrl->setControlTrackProfile(mGroup->mInspector->mTrackProfile);
   retCtrl->setControlBackgroundProfile(mGroup->mInspector->mBackgroundProfile);
   retCtrl->setConstantThumbHeight(mGroup->mInspector->mUseConstantHeightThumb);
   retCtrl->setShowArrowButtons(mGroup->mInspector->mShowArrowButtons);
   retCtrl->setScrollBarThickness(mGroup->mInspector->mScrollBarThickness);

   registerEditControl( retCtrl );

   // Configure it to update our value when the popup is closed
   char szBuffer[512];
   dSprintf( szBuffer, 512, "%d.%s = %d.getText();",mTarget->getId(), mField->pFieldname, retCtrl->getId() );
   retCtrl->setField("Command", szBuffer );
   retCtrl->mBounds.set(mGroup->mInspector->mControlOffset, Point2I(width - mGroup->mInspector->mControlOffset.x, 28));

   //now add the entries
   GuiListBoxCtrl* list = retCtrl->getList();
   EnumTable::Enums* table = mField->table->table;
   for(S32 i = 0; i < mField->table->size; i++)
   {
	   list->addItemWithID(table[i].label, table[i].index);
   }
   retCtrl->setField("text", getData());

   return retCtrl;
}

void GuiInspectorTypeEnum::consoleInit()
{
   Parent::consoleInit();

   ConsoleBaseType::getType(TypeEnum)->setInspectorFieldType("GuiInspectorTypeEnum");
}

void GuiInspectorTypeEnum::updateValue( StringTableEntry newValue )
{
	newValue = StringTable->insert(newValue, true);//despite the type already being a StringTableEntry, sometimes plain const char* are sent instead.
	GuiDropDownCtrl *ctrl = dynamic_cast<GuiDropDownCtrl*>( mEdit );
	if (ctrl != NULL)
	{
		ctrl->getList()->setSelectionInternal(newValue);
	}
}

void GuiInspectorTypeEnum::setData( StringTableEntry data )
{
   if( mField == NULL || mTarget == NULL )
      return;

   mTarget->setDataField( mField->pFieldname, NULL, data );

   // Force our edit to update
   updateValue( data );
}

StringTableEntry  GuiInspectorTypeEnum::getData()
{
   if( mField == NULL || mTarget == NULL )
      return "";

   return mTarget->getDataField( mField->pFieldname, NULL );
}

//////////////////////////////////////////////////////////////////////////
// GuiInspectorTypeCheckBox 
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypeCheckBox);

GuiControl* GuiInspectorTypeCheckBox::constructEditControl(S32 width)
{
	GuiCheckBoxCtrl* retCtrl = new GuiCheckBoxCtrl();

	// If we couldn't construct the control, bail!
	if( retCtrl == NULL )
		return retCtrl;

	// Let's make it look pretty.
	retCtrl->setControlProfile(mGroup->mInspector->mCheckboxProfile);

	retCtrl->setText(mText);
	mText = StringTable->EmptyString;
	retCtrl->setScriptValue( getData() );

	registerEditControl( retCtrl );

	// Configure it to update our value when the popup is closed
	char szBuffer[512];
	dSprintf( szBuffer, 512, "%d.apply(%d.getValue());",getId(),retCtrl->getId() );
	retCtrl->setField("Command", szBuffer );
	retCtrl->mBounds.set(mGroup->mInspector->mControlOffset, Point2I(width - mGroup->mInspector->mControlOffset.x, 30));
	retCtrl->setTextExtent(Point2I(retCtrl->getExtent().x - retCtrl->getTextOffset().x, retCtrl->getExtent().y - retCtrl->getTextOffset().y));

	return retCtrl;
}


void GuiInspectorTypeCheckBox::consoleInit()
{
   Parent::consoleInit();

   ConsoleBaseType::getType(TypeBool)->setInspectorFieldType("GuiInspectorTypeCheckBox");
}

//////////////////////////////////////////////////////////////////////////
// GuiInspectorTypeGuiProfile 
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypeGuiProfile);

void GuiInspectorTypeGuiProfile::consoleInit()
{
   Parent::consoleInit();

   ConsoleBaseType::getType(TypeGuiProfile)->setInspectorFieldType("GuiInspectorTypeGuiProfile");
}

static S32 QSORT_CALLBACK stringCompare(const void *a,const void *b)
{
   StringTableEntry sa = *(StringTableEntry*)a;
   StringTableEntry sb = *(StringTableEntry*)b;
   return(dStricmp(sa, sb));
}

GuiControl* GuiInspectorTypeGuiProfile::constructEditControl(S32 width)
{
	GuiDropDownCtrl* retCtrl = new GuiDropDownCtrl();

   // If we couldn't construct the control, bail!
   if( retCtrl == NULL )
      return retCtrl;

   // Let's make it look pretty.
   retCtrl->setControlProfile(mGroup->mInspector->mDropDownProfile);
   retCtrl->setControlListBoxProfile(mGroup->mInspector->mDropDownItemProfile);
   retCtrl->setControlScrollProfile(mGroup->mInspector->mScrollProfile);
   retCtrl->setControlThumbProfile(mGroup->mInspector->mThumbProfile);
   retCtrl->setControlArrowProfile(mGroup->mInspector->mArrowProfile);
   retCtrl->setControlTrackProfile(mGroup->mInspector->mTrackProfile);
   retCtrl->setControlBackgroundProfile(mGroup->mInspector->mBackgroundProfile);
   retCtrl->setConstantThumbHeight(mGroup->mInspector->mUseConstantHeightThumb);
   retCtrl->setShowArrowButtons(mGroup->mInspector->mShowArrowButtons);
   retCtrl->setScrollBarThickness(mGroup->mInspector->mScrollBarThickness);

   registerEditControl( retCtrl );

   // Configure it to update our value when the popup is closed
   char szBuffer[512];
   dSprintf( szBuffer, 512, "%d.apply(%d.getText());",getId(),retCtrl->getId() );
   retCtrl->setField("Command", szBuffer );
   retCtrl->mBounds.set(mGroup->mInspector->mControlOffset, Point2I(width - mGroup->mInspector->mControlOffset.x, 28));

   Vector<StringTableEntry> entries;

   SimGroup * grp = Sim::getGuiDataGroup();
   for(SimGroup::iterator i = grp->begin(); i != grp->end(); i++)
   {
      GuiControlProfile * profile = dynamic_cast<GuiControlProfile *>(*i);
      if(profile && profile->getName())
      {
		StringTableEntry name = StringTable->insert(profile->getName());
		if(name != StringTable->EmptyString)
		{
			entries.push_back(name);
		}
      }
   }

   for(U32 j = 0; j < (U32)entries.size(); j++)
   {
		if(entries[j] != NULL)
		{
			retCtrl->getList()->addItem(entries[j]);
		}
   }
   retCtrl->getList()->sortByText();
   retCtrl->setField("text", getData());

   return retCtrl;
}

//////////////////////////////////////////////////////////////////////////
// GuiInspectorTypeGuiBorderProfile 
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypeGuiBorderProfile);

void GuiInspectorTypeGuiBorderProfile::consoleInit()
{
   Parent::consoleInit();

   ConsoleBaseType::getType(TypeGuiBorderProfile)->setInspectorFieldType("GuiInspectorTypeGuiBorderProfile");
}

GuiControl* GuiInspectorTypeGuiBorderProfile::constructEditControl(S32 width)
{
	GuiDropDownCtrl* retCtrl = new GuiDropDownCtrl();

   // If we couldn't construct the control, bail!
   if (retCtrl == NULL)
      return retCtrl;

   // Let's make it look pretty.
   retCtrl->setControlProfile(mGroup->mInspector->mDropDownProfile);
   retCtrl->setControlListBoxProfile(mGroup->mInspector->mDropDownItemProfile);
   retCtrl->setControlScrollProfile(mGroup->mInspector->mScrollProfile);
   retCtrl->setControlThumbProfile(mGroup->mInspector->mThumbProfile);
   retCtrl->setControlArrowProfile(mGroup->mInspector->mArrowProfile);
   retCtrl->setControlTrackProfile(mGroup->mInspector->mTrackProfile);
   retCtrl->setControlBackgroundProfile(mGroup->mInspector->mBackgroundProfile);
   retCtrl->setConstantThumbHeight(mGroup->mInspector->mUseConstantHeightThumb);
   retCtrl->setShowArrowButtons(mGroup->mInspector->mShowArrowButtons);
   retCtrl->setScrollBarThickness(mGroup->mInspector->mScrollBarThickness);

   registerEditControl(retCtrl);

   // Configure it to update our value when the popup is closed
   char szBuffer[512];
   dSprintf(szBuffer, 512, "%d.apply(%d.getText());", getId(), retCtrl->getId());
   retCtrl->setField("Command", szBuffer);
   retCtrl->mBounds.set(mGroup->mInspector->mControlOffset, Point2I(width - mGroup->mInspector->mControlOffset.x, 28));

   Vector<StringTableEntry> entries;

   SimGroup * grp = Sim::getGuiDataGroup();
   for (SimGroup::iterator i = grp->begin(); i != grp->end(); i++)
   {
      GuiBorderProfile * profile = dynamic_cast<GuiBorderProfile *>(*i);
	  if (profile && profile->getName())
	  {
		  StringTableEntry name = StringTable->insert(profile->getName());
		  if (name != StringTable->EmptyString)
		  {
			  entries.push_back(name);
		  }
	  }
   }

   for (U32 j = 0; j < (U32)entries.size(); j++)
   {
	   if (entries[j] != NULL)
	   {
		   retCtrl->getList()->addItem(entries[j]);
	   }
   }
   retCtrl->getList()->sortByText();
   retCtrl->setField("text", getData());

   return retCtrl;
}

//////////////////////////////////////////////////////////////////////////
// GuiInspectorTypeGuiCursor
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypeGuiCursor);

void GuiInspectorTypeGuiCursor::consoleInit()
{
	Parent::consoleInit();

	ConsoleBaseType::getType(TypeGuiCursor)->setInspectorFieldType("GuiInspectorTypeGuiCursor");
}

GuiControl* GuiInspectorTypeGuiCursor::constructEditControl(S32 width)
{
	GuiDropDownCtrl* retCtrl = new GuiDropDownCtrl();

	// If we couldn't construct the control, bail!
	if (retCtrl == NULL)
		return retCtrl;

	// Let's make it look pretty.
	retCtrl->setControlProfile(mGroup->mInspector->mDropDownProfile);
	retCtrl->setControlListBoxProfile(mGroup->mInspector->mDropDownItemProfile);
	retCtrl->setControlScrollProfile(mGroup->mInspector->mScrollProfile);
	retCtrl->setControlThumbProfile(mGroup->mInspector->mThumbProfile);
	retCtrl->setControlArrowProfile(mGroup->mInspector->mArrowProfile);
	retCtrl->setControlTrackProfile(mGroup->mInspector->mTrackProfile);
	retCtrl->setControlBackgroundProfile(mGroup->mInspector->mBackgroundProfile);
	retCtrl->setConstantThumbHeight(mGroup->mInspector->mUseConstantHeightThumb);
	retCtrl->setShowArrowButtons(mGroup->mInspector->mShowArrowButtons);
	retCtrl->setScrollBarThickness(mGroup->mInspector->mScrollBarThickness);

	registerEditControl(retCtrl);

	// Configure it to update our value when the popup is closed
	char szBuffer[512];
	dSprintf(szBuffer, 512, "%d.apply(%d.getText());", getId(), retCtrl->getId());
	retCtrl->setField("Command", szBuffer);
	retCtrl->mBounds.set(mGroup->mInspector->mControlOffset, Point2I(width - mGroup->mInspector->mControlOffset.x, 28));

	Vector<StringTableEntry> entries;

	SimGroup* grp = Sim::getGuiDataGroup();
	for (SimGroup::iterator i = grp->begin(); i != grp->end(); i++)
	{
		GuiCursor* profile = dynamic_cast<GuiCursor*>(*i);
		if (profile && profile->getName())
		{
			StringTableEntry name = StringTable->insert(profile->getName());
			if (name != StringTable->EmptyString)
			{
				entries.push_back(name);
			}
		}
	}

	for (U32 j = 0; j < (U32)entries.size(); j++)
	{
		if (entries[j] != NULL)
		{
			retCtrl->getList()->addItem(entries[j]);
		}
	}
	retCtrl->getList()->sortByText();
	retCtrl->setField("text", getData());

	return retCtrl;
}


//////////////////////////////////////////////////////////////////////////
// GuiInspectorTypeFileName 
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypeFileName);

void GuiInspectorTypeFileName::consoleInit()
{
   Parent::consoleInit();

   ConsoleBaseType::getType(TypeFilename)->setInspectorFieldType("GuiInspectorTypeFileName");
}

GuiControl* GuiInspectorTypeFileName::constructEditControl(S32 width)
{
   GuiControl* retCtrl = new GuiControl();

   // If we couldn't construct the control, bail!
   if( retCtrl == NULL )
      return retCtrl;

   // Let's make it look pretty.
   retCtrl->setControlProfile(mGroup->mInspector->mTextEditProfile);

   // Don't forget to register ourselves
   registerEditControl( retCtrl );

   char szBuffer[512];
   dSprintf( szBuffer, 512, "%d.apply(%d.getText());",getId(),retCtrl->getId() );
   retCtrl->setField("AltCommand", szBuffer );
   retCtrl->mBounds.set(mGroup->mInspector->mControlOffset, Point2I(width - (mGroup->mInspector->mControlOffset.x + 34), 30));

   mBrowseButton = new GuiButtonCtrl();

   if( mBrowseButton != NULL )
   {
      char szBuffer[512];
      dSprintf( szBuffer, 512, "getLoadFilename(\"*.*\", \"%d.apply\", \"%s\");",getId(), getData());
      mBrowseButton->setField( "Command", szBuffer );
      mBrowseButton->setField( "text", "..." ); 
	  mBrowseButton->setControlProfile(mGroup->mInspector->mButtonProfile);
      mBrowseButton->registerObject();
      mBrowseButton->setExtent(Point2I(30, 28));
      mBrowseButton->setPosition(Point2I(mGroup->mInspector->mControlOffset.x + retCtrl->getWidth() + 4, mGroup->mInspector->mControlOffset.y + 1));
      addObject( mBrowseButton );
   }

   return retCtrl;
}

void GuiInspectorTypeFileName::resize( const Point2I &newPosition, const Point2I &newExtent )
{
   Parent::resize( newPosition, newExtent );
}

//////////////////////////////////////////////////////////////////////////
// GuiInspectorTypeColor (Base for ColorI/ColorF) 
//////////////////////////////////////////////////////////////////////////
GuiControl* GuiInspectorTypeColor::constructEditControl(S32 width)
{
	GuiControl* retCtrl = new GuiControl();

	// If we couldn't construct the control, bail!
	if (retCtrl == NULL)
		return retCtrl;

	// Let's make it look pretty.
	retCtrl->setControlProfile(mGroup->mInspector->mBackgroundProfile);
	retCtrl->mBounds.set(mGroup->mInspector->mControlOffset, Point2I(width - mGroup->mInspector->mControlOffset.x, 52));

	// Don't forget to register ourselves
	registerEditControl(retCtrl);

	constructColorPopup(retCtrl);
	constructColorEditBoxes(retCtrl, (width - 32) - mGroup->mInspector->mControlOffset.x);
	finishControlConstruction();

	const char* color = getData();
	updateValue(color);

	return retCtrl;
}

void GuiInspectorTypeColor::constructColorPopup(GuiControl* retCtrl)
{
	mColorPopup = new GuiColorPopupCtrl();
	if (mColorPopup == NULL)
		return;

	mColorPopup->setControlProfile(mGroup->mInspector->mColorPopupProfile);
	mColorPopup->setControlBackgroundProfile(mGroup->mInspector->mBackgroundProfile);
	mColorPopup->setControlPopupProfile(mGroup->mInspector->mColorPopupPanelProfile);
	mColorPopup->setControlPickerProfile(mGroup->mInspector->mColorPopupPickerProfile);
	mColorPopup->setControlSelectorProfile(mGroup->mInspector->mColorPopupSelectorProfile);
	registerEditControl(mColorPopup);

	const char* mCol = getData();
	mColorPopup->setField("BaseColor", mCol);
	char szBuffer[512];
	dSprintf(szBuffer, 512, "%d.apply(%d.%s());", getId(), mColorPopup->getId(), mColorFunction);
	mColorPopup->setField("Command", szBuffer);
	mColorPopup->mBounds.set(Point2I(0, 0), Point2I(32, 32));

	retCtrl->addObject(mColorPopup);
}

void GuiInspectorTypeColor::constructColorEditBoxes(GuiControl* retCtrl, S32 width)
{
	const S32 w = mFloor(width / 4);
	const S32 x = 32;
	mRedEdit = constructColorEditBox(retCtrl, x, w, StringTable->insert("R", true));
	mGreenEdit = constructColorEditBox(retCtrl, x + w, w, StringTable->insert("G", true));
	mBlueEdit = constructColorEditBox(retCtrl, x + (2 * w), w, StringTable->insert("B", true));
	mAlphaEdit = constructColorEditBox(retCtrl, x + (3 * w), w, StringTable->insert("A", true));

	char szCommand[512];
	dSprintf(szCommand, 512, "%d.apply(%d.getText() SPC %d.getText() SPC %d.getText() SPC %d.getText());",
		getId(), mRedEdit->getId(), mGreenEdit->getId(), mBlueEdit->getId(), mAlphaEdit->getId());
	mRedEdit->setField("AltCommand", szCommand);
	mGreenEdit->setField("AltCommand", szCommand);
	mBlueEdit->setField("AltCommand", szCommand);
	mAlphaEdit->setField("AltCommand", szCommand);
}

GuiTextEditCtrl* GuiInspectorTypeColor::constructColorEditBox(GuiControl* retCtrl, S32 posX, S32 width, StringTableEntry text)
{
	GuiTextEditCtrl* textEdit = new GuiTextEditCtrl();
	registerEditControl(textEdit);

	GuiControl* label = new GuiControl();
	registerEditControl(label);

	textEdit->setControlProfile(mGroup->mInspector->mTextEditProfile);
	label->setControlProfile(mGroup->mInspector->mLabelProfile);

	label->resize(Point2I(posX, 32), Point2I(width, 20));
	label->setField("text", text);
	label->setField("align", "center");
	label->setField("fontSizeAdjust", "0.8");

	textEdit->resize(Point2I(posX, 0), Point2I(width, 30));
	textEdit->setInputMode(GuiTextEditCtrl::InputMode::Number);
	textEdit->setField("align", "center");

	retCtrl->addObject(label);
	retCtrl->addObject(textEdit);

	return textEdit;
}

//////////////////////////////////////////////////////////////////////////
// GuiInspectorTypeColorI
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypeColorI);

void GuiInspectorTypeColorI::consoleInit()
{
   Parent::consoleInit();

   ConsoleBaseType::getType(TypeColorI)->setInspectorFieldType("GuiInspectorTypeColorI");
}

GuiInspectorTypeColorI::GuiInspectorTypeColorI()
{
   mColorFunction = StringTable->insert("getColorI");
}

void GuiInspectorTypeColorI::updateValue(StringTableEntry newValue)
{
	if (Utility::mGetStringElementCount(newValue) != 4)
	{
		return;
	}

	S32 red = dAtoi(Utility::mGetStringElement(newValue, 0));
	S32 green = dAtoi(Utility::mGetStringElement(newValue, 1));
	S32 blue = dAtoi(Utility::mGetStringElement(newValue, 2));
	S32 alpha = dAtoi(Utility::mGetStringElement(newValue, 3));

	ColorF color = ColorI(red, green, blue, alpha);
	mColorPopup->setColor(color);

	mRedEdit->setText(Utility::mGetStringElement(newValue, 0));
	mGreenEdit->setText(Utility::mGetStringElement(newValue, 1));
	mBlueEdit->setText(Utility::mGetStringElement(newValue, 2));
	mAlphaEdit->setText(Utility::mGetStringElement(newValue, 3));
}

void GuiInspectorTypeColorI::finishControlConstruction()
{
}

//////////////////////////////////////////////////////////////////////////
// GuiInspectorTypeColorF
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypeColorF);

void GuiInspectorTypeColorF::consoleInit()
{
   Parent::consoleInit();

   ConsoleBaseType::getType(TypeColorF)->setInspectorFieldType("GuiInspectorTypeColorF");
}

GuiInspectorTypeColorF::GuiInspectorTypeColorF()
{
   mColorFunction = StringTable->insert("getColorF");
}

void GuiInspectorTypeColorF::updateValue(StringTableEntry newValue)
{
	if (Utility::mGetStringElementCount(newValue) != 4)
	{
		return;
	}

	F32 red = mFabs(mRound(100 * dAtof(Utility::mGetStringElement(newValue, 0))) / 100.0f);
	F32 green = mFabs(mRound(100 * dAtof(Utility::mGetStringElement(newValue, 1))) / 100.0f);
	F32 blue = mFabs(mRound(100 * dAtof(Utility::mGetStringElement(newValue, 2))) / 100.0f);
	F32 alpha = mFabs(mRound(100 * dAtof(Utility::mGetStringElement(newValue, 3))) / 100.0f);

	ColorF color = ColorF(red, green, blue, alpha);
	mColorPopup->setColor(color);

	char redText[10];
	dSprintf(redText, 10, "%.2f", red);
	mRedEdit->setText(redText);

	char greenText[10];
	dSprintf(greenText, 10, "%.2f", green);
	mGreenEdit->setText(greenText);

	char blueText[10];
	dSprintf(blueText, 10, "%.2f", blue);
	mBlueEdit->setText(blueText);

	char alphaText[10];
	dSprintf(alphaText, 10, "%.2f", alpha);
	mAlphaEdit->setText(alphaText);
}

void GuiInspectorTypeColorF::finishControlConstruction()
{
	mRedEdit->setInputMode(GuiTextEditCtrl::InputMode::Decimal);
	mGreenEdit->setInputMode(GuiTextEditCtrl::InputMode::Decimal);
	mBlueEdit->setInputMode(GuiTextEditCtrl::InputMode::Decimal);
	mAlphaEdit->setInputMode(GuiTextEditCtrl::InputMode::Decimal);
}


IMPLEMENT_CONOBJECT(GuiInspectorTypeFluidColorI);

void GuiInspectorTypeFluidColorI::consoleInit()
{
	Parent::consoleInit();

	ConsoleBaseType::getType(TypeFluidColorI)->setInspectorFieldType("GuiInspectorTypeFluidColorI");
}

GuiInspectorTypeFluidColorI::GuiInspectorTypeFluidColorI()
{
	mColorFunction = StringTable->insert("getColorI");
}

void GuiInspectorTypeFluidColorI::updateValue(StringTableEntry newValue)
{
	if (Utility::mGetStringElementCount(newValue) != 4)
	{
		return;
	}

	S32 red = dAtoi(Utility::mGetStringElement(newValue, 0));
	S32 green = dAtoi(Utility::mGetStringElement(newValue, 1));
	S32 blue = dAtoi(Utility::mGetStringElement(newValue, 2));
	S32 alpha = dAtoi(Utility::mGetStringElement(newValue, 3));

	ColorF color = ColorI(red, green, blue, alpha);
	mColorPopup->setColor(color);

	mRedEdit->setText(Utility::mGetStringElement(newValue, 0));
	mGreenEdit->setText(Utility::mGetStringElement(newValue, 1));
	mBlueEdit->setText(Utility::mGetStringElement(newValue, 2));
	mAlphaEdit->setText(Utility::mGetStringElement(newValue, 3));
}

void GuiInspectorTypeFluidColorI::finishControlConstruction()
{
}


//////////////////////////////////////////////////////////////////////////
// TypeSimObjectPtr GuiInspectorField Class
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypeSimObjectPtr);

void GuiInspectorTypeSimObjectPtr::consoleInit()
{
   Parent::consoleInit();

   ConsoleBaseType::getType(TypeSimObjectPtr)->setInspectorFieldType("GuiInspectorTypeSimObjectPtr");
}

GuiControl * GuiInspectorTypeSimObjectPtr::constructEditControl(S32 width)
{
   GuiControl* retCtrl = new GuiControl();

   // If we couldn't construct the control, bail!
   if (retCtrl == NULL)
      return retCtrl;

   // Let's make it look pretty.
   retCtrl->setControlProfile(mGroup->mInspector->mLabelProfile);

   // Don't forget to register ourselves
   registerEditControl(retCtrl);

   retCtrl->mBounds.set(mGroup->mInspector->mControlOffset, Point2I(width - mGroup->mInspector->mControlOffset.x, 30));
   retCtrl->setField("text", getData());

   return retCtrl;

}

StringTableEntry GuiInspectorTypeSimObjectPtr::getData()
{
   if (mField == NULL || mTarget == NULL)
      return "";

   return mTarget->getDataField(mField->pFieldname, NULL);
}

//////////////////////////////////////////////////////////////////////////
// TypeS32 GuiInspectorField Class
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypeS32);

void GuiInspectorTypeS32::consoleInit()
{
   Parent::consoleInit();

   ConsoleBaseType::getType(TypeS32)->setInspectorFieldType("GuiInspectorTypeS32");
}

GuiControl * GuiInspectorTypeS32::constructEditControl(S32 width)
{
   const char* mData = getData();
   const char* mName = mField->pFieldname; 
   U32 mCount = 1;
   if (mName == StringTable->insert("CollisionGroups") || mName == StringTable->insert("CollisionLayers"))
   {
      mCount = 32;
   }

   // this is just here for Collision layers and groups, needs to be swapped over to a different type.
   if (mCount == 32)
   {
      GuiGridCtrl *retCtrl = new GuiGridCtrl();
      registerEditControl(retCtrl);

	  retCtrl->mCellModeX = GuiGridCtrl::Absolute;
	  retCtrl->mCellModeY = GuiGridCtrl::Absolute;
	  retCtrl->mCellSpacingX = 8;
	  retCtrl->mCellSpacingY = 4;

	  retCtrl->mBounds.set(mGroup->mInspector->mControlOffset, Point2I(width - mGroup->mInspector->mControlOffset.x, 30));

	  U32 labelWidth = mGroup->mInspector->mLabelProfile->getFont(mFontSizeAdjust)->getStrWidth("00");
	  U32 x = 0, y = 0;
      for (U32 i = 0; i < mCount; i++)
      {
         char szName[32];
         dSprintf(szName, 32, "%d", i);

         // create our checkboxes.
         GuiCheckBoxCtrl* checkBox = new GuiCheckBoxCtrl;
         registerEditControl(checkBox);
		 checkBox->setControlProfile(mGroup->mInspector->mCheckboxProfile);
		 checkBox->setTextOffset(Point2I(2,0));
		 checkBox->setTextExtent(Point2I(labelWidth + 2, checkBox->mProfile->getFont(mFontSizeAdjust)->getHeight() + 2));
		 checkBox->setBoxOffset(Point2I(checkBox->getTextExtent().x + 2, 0));
		 checkBox->setText(szName);

         // collision group and layer default to on.
         const char* val = StringUnit::getUnit(mData, i, " ");
         if (StringTable->insert(szName) == StringTable->insert(val))
         {
            checkBox->setStateOn(true);
         }
         // say hello to my really big friend.
         char szBuffer[512];
         dSprintf(szBuffer, 512, "CollisionArrayUpdate(%d,\"%s\", \"%s\", %d, \"%d.apply\");",
            mTarget->getId(), mName,szName,checkBox->getId(),getId());

         checkBox->setField("Command", szBuffer);

		 if (i == 0)
		 {
			 U32 xNeeded = checkBox->getBoxOffset().x + checkBox->getBoxExtent().x;
			 U32 yNeeded = checkBox->getBoxOffset().y + checkBox->getBoxExtent().y;
          Point2I needed = Point2I(xNeeded, yNeeded);
			 Point2I outerExt = checkBox->getOuterExtent(needed, NormalState, checkBox->mProfile);

			 x = (U32)outerExt.x;
			 y = (U32)outerExt.y;
		 }

         retCtrl->addObject(checkBox);
      }

      GuiButtonCtrl* allButton = new GuiButtonCtrl;
	  allButton->setControlProfile(mGroup->mInspector->mButtonProfile);
      registerEditControl(allButton);

      GuiButtonCtrl* noneButton = new GuiButtonCtrl;
	  noneButton->setControlProfile(mGroup->mInspector->mButtonProfile);
      registerEditControl(noneButton);

      allButton->setText("All");
      noneButton->setText("None");
      Point2I innerExt = Point2I(noneButton->mProfile->getFont(mFontSizeAdjust)->getStrWidth("None"), noneButton->mProfile->getFont(mFontSizeAdjust)->getHeight());
	   Point2I buttonExt = noneButton->getOuterExtent(innerExt, NormalState, noneButton->mProfile);

      retCtrl->mCellSizeX = getMax(x, (U32)buttonExt.x);
      retCtrl->mCellSizeY = getMax(y, (U32)buttonExt.y);

      char szBufferAll[512];
      dSprintf(szBufferAll, 512, "%d.apply(\"all\");", getId());
      allButton->setField("Command", szBufferAll);

      dSprintf(szBufferAll, 512, "%d.apply(\"none\");", getId());
      noneButton->setField("Command", szBufferAll);

      retCtrl->addObject(allButton);
      retCtrl->addObject(noneButton);

	  return retCtrl;
   }
   else
   {
      GuiControl* retCtrl = GuiInspectorField::constructEditControl(width);
	  GuiTextEditCtrl *editCtrl = dynamic_cast<GuiTextEditCtrl*>(retCtrl);
	  editCtrl->setInputMode(GuiTextEditCtrl::InputMode::Number);

	  return editCtrl;
   }
}

const char* GuiInspectorTypeS32::getData()
{
   if (mField == NULL || mTarget == NULL)
      return "";

   return mTarget->getDataField(mField->pFieldname, NULL);
}

//////////////////////////////////////////////////////////////////////////
// DualValue GuiInspectorField Class
//////////////////////////////////////////////////////////////////////////
void GuiInspectorTypeDualValue::constructEditControlChildren(GuiControl* retCtrl, S32 width)
{
	// make our x fields.
	mCtrlX = new GuiTextEditCtrl();
	GuiControl* mLabelX = new GuiControl();

	// make our y fields.
	mCtrlY = new GuiTextEditCtrl();
	GuiControl* mLabelY = new GuiControl();

	// Don't forget to register ourselves
	registerEditControl(mCtrlX);
	registerEditControl(mCtrlY);

	// Let's make it look pretty.
	mCtrlX->setControlProfile(mGroup->mInspector->mTextEditProfile);
	mCtrlY->setControlProfile(mGroup->mInspector->mTextEditProfile);
	mLabelX->setControlProfile(mGroup->mInspector->mLabelProfile);
	mLabelY->setControlProfile(mGroup->mInspector->mLabelProfile);

	// make and position our controls.
	S32 labelWidth = 20;
	mLabelX->setExtent(Point2I(labelWidth, 30));
	mLabelY->setExtent(Point2I(labelWidth, 30));
	mLabelX->setField("align", "center");
	mLabelX->setField("vAlign", "middle");
	mLabelY->setField("align", "center");
	mLabelY->setField("vAlign", "middle");
	mLabelX->setField("text", "X");
	mLabelY->setField("text", "Y");

	S32 halfX = mCeil(width / 2);
	mLabelY->setPosition(Point2I(halfX, 0));

	mCtrlX->setExtent(Point2I(halfX - labelWidth, 30));
	mCtrlY->setExtent(Point2I(halfX - labelWidth, 30));

	char szCommand[512];

	dSprintf(szCommand, 512, "%d.apply(%d.getText() SPC %d.getText());", getId(), mCtrlX->getId(), mCtrlY->getId());

	mCtrlX->setPosition(Point2I(labelWidth, 0));
	mCtrlY->setPosition(Point2I(halfX + labelWidth, 0));

	mCtrlX->setInputMode(GuiTextEditCtrl::InputMode::Number);
	mCtrlY->setInputMode(GuiTextEditCtrl::InputMode::Number);

	mCtrlX->setField("AltCommand", szCommand);
	mCtrlY->setField("AltCommand", szCommand);

	retCtrl->addObject(mLabelX);
	retCtrl->addObject(mLabelY);
	retCtrl->addObject(mCtrlX);
	retCtrl->addObject(mCtrlY);
}

void GuiInspectorTypeDualValue::updateValue(StringTableEntry newValue)
{
	U32 elementCount = Utility::mGetStringElementCount(newValue);

	if (elementCount > 0)
	{
		mCtrlX->setText(StringUnit::getUnit(newValue, 0, " \t\n"));
	}
	if (elementCount > 1)
	{
		mCtrlY->setText(StringUnit::getUnit(newValue, 1, " \t\n"));
	}
}

//////////////////////////////////////////////////////////////////////////
// TypePoint2I GuiInspectorField Class
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypePoint2I);

void GuiInspectorTypePoint2I::consoleInit()
{
   Parent::consoleInit();

   ConsoleBaseType::getType(TypePoint2I)->setInspectorFieldType("GuiInspectorTypePoint2I");
}

GuiControl * GuiInspectorTypePoint2I::constructEditControl(S32 width)
{
	GuiControl* retCtrl = new GuiControl();

	// If we couldn't construct the control, bail!
	if (retCtrl == NULL)
		return retCtrl;

	// Let's make it look pretty.
	retCtrl->setControlProfile(mGroup->mInspector->mBackgroundProfile);
	retCtrl->mBounds.set(mGroup->mInspector->mControlOffset, Point2I(width - mGroup->mInspector->mControlOffset.x, 30));

	// Don't forget to register ourselves
	registerEditControl(retCtrl);

	constructEditControlChildren(retCtrl, width - mGroup->mInspector->mControlOffset.x);

	return retCtrl;
}

//////////////////////////////////////////////////////////////////////////
// TypePoint2F GuiInspectorField Class
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypePoint2F);

void GuiInspectorTypePoint2F::consoleInit()
{
   Parent::consoleInit();

   ConsoleBaseType::getType(TypePoint2F)->setInspectorFieldType("GuiInspectorTypePoint2F");
}

GuiControl * GuiInspectorTypePoint2F::constructEditControl(S32 width)
{
	GuiControl* retCtrl = new GuiControl();

	// If we couldn't construct the control, bail!
	if (retCtrl == NULL)
		return retCtrl;

	// Let's make it look pretty.
	retCtrl->setControlProfile(mGroup->mInspector->mBackgroundProfile);
	retCtrl->mBounds.set(mGroup->mInspector->mControlOffset, Point2I(width - mGroup->mInspector->mControlOffset.x, 30));

	// Don't forget to register ourselves
	registerEditControl(retCtrl);

	constructEditControlChildren(retCtrl, width - mGroup->mInspector->mControlOffset.x);

	mCtrlX->setInputMode(GuiTextEditCtrl::InputMode::Decimal);
	mCtrlY->setInputMode(GuiTextEditCtrl::InputMode::Decimal);

	return retCtrl;
}

//////////////////////////////////////////////////////////////////////////
// TypeVector2 GuiInspectorField Class
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypeVector2);

void GuiInspectorTypeVector2::consoleInit()
{
   Parent::consoleInit();

   ConsoleBaseType::getType(TypeVector2)->setInspectorFieldType("GuiInspectorTypeVector2");
}

GuiControl * GuiInspectorTypeVector2::constructEditControl(S32 width)
{
	GuiControl* retCtrl = new GuiControl();

	// If we couldn't construct the control, bail!
	if (retCtrl == NULL)
		return retCtrl;

	// Let's make it look pretty.
	retCtrl->setControlProfile(mGroup->mInspector->mBackgroundProfile);
	retCtrl->mBounds.set(mGroup->mInspector->mControlOffset, Point2I(width - mGroup->mInspector->mControlOffset.x, 30));

	// Don't forget to register ourselves
	registerEditControl(retCtrl);

	constructEditControlChildren(retCtrl, width - mGroup->mInspector->mControlOffset.x);

	mCtrlX->setInputMode(GuiTextEditCtrl::InputMode::Decimal);
	mCtrlY->setInputMode(GuiTextEditCtrl::InputMode::Decimal);

	return retCtrl;
}

//////////////////////////////////////////////////////////////////////////
// TypeAsset GuiInspectorField Class Base for Assets
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypeAsset);

GuiControl* GuiInspectorTypeAsset::constructEditControl(S32 width)
{
   // we don't need a custom update for this.
   // the object is a guicontrol and therefore 
   // just needs the text value of the asset.
   GuiControl* retCtrl = new GuiControl();

   // If we couldn't construct the control, bail!
   if (retCtrl == NULL)
      return retCtrl;

   // Let's make it look pretty.
   retCtrl->setControlProfile(mGroup->mInspector->mLabelProfile);

   // Don't forget to register ourselves
   registerEditControl(retCtrl);

   retCtrl->mBounds.set(mGroup->mInspector->mControlOffset, Point2I(width - (mGroup->mInspector->mControlOffset.x + 34), 30));
   retCtrl->setText(getData());

   mBrowseButton = new GuiButtonCtrl();

   if (mBrowseButton != NULL)
   {

      char szBuffer[512];
      dSprintf(szBuffer, 512, "getAsset(\"%d.apply\", \"%s\", \"%s\");", getId(), getData(), mAssetType);
      mBrowseButton->setField("Command", szBuffer);
      mBrowseButton->setField("text", "...");
	  mBrowseButton->setControlProfile(mGroup->mInspector->mButtonProfile);
	  mBrowseButton->registerObject();
	  mBrowseButton->setExtent(Point2I(30, 28));
	  mBrowseButton->setPosition(Point2I(mGroup->mInspector->mControlOffset.x + retCtrl->getWidth() + 4, mGroup->mInspector->mControlOffset.y + 1));
      retCtrl->addObject(mBrowseButton);

   }

   return retCtrl;
}

//////////////////////////////////////////////////////////////////////////
// TypeImageAssetPtr GuiInspectorField Class
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypeImageAssetPtr);

GuiInspectorTypeImageAssetPtr::GuiInspectorTypeImageAssetPtr()
{
   mAssetType = StringTable->insert("ImageAsset");
}

void GuiInspectorTypeImageAssetPtr::consoleInit()
{
   Parent::consoleInit();

   ConsoleBaseType::getType(TypeImageAssetPtr)->setInspectorFieldType("GuiInspectorTypeImageAssetPtr");
}

//////////////////////////////////////////////////////////////////////////
// TypeAnimationAssetPtr GuiInspectorField Class
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypeAnimationAssetPtr);

GuiInspectorTypeAnimationAssetPtr::GuiInspectorTypeAnimationAssetPtr()
{
   mAssetType = StringTable->insert("AnimationAsset");
}

void GuiInspectorTypeAnimationAssetPtr::consoleInit()
{
   Parent::consoleInit();

   ConsoleBaseType::getType(TypeAnimationAssetPtr)->setInspectorFieldType("GuiInspectorTypeAnimationAssetPtr");
}

//////////////////////////////////////////////////////////////////////////
// TypeAudioAssetPtr GuiInspectorField Class
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypeAudioAssetPtr);

GuiInspectorTypeAudioAssetPtr::GuiInspectorTypeAudioAssetPtr()
{
   mAssetType = StringTable->insert("AudioAsset");
}

void GuiInspectorTypeAudioAssetPtr::consoleInit()
{
   Parent::consoleInit();

   ConsoleBaseType::getType(TypeAudioAssetPtr)->setInspectorFieldType("GuiInspectorTypeAudioAssetPtr");
}

//////////////////////////////////////////////////////////////////////////
// TypeFontAssetPtr GuiInspectorField Class
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypeFontAssetPtr);

GuiInspectorTypeFontAssetPtr::GuiInspectorTypeFontAssetPtr()
{
   mAssetType = StringTable->insert("FontAsset");
}

void GuiInspectorTypeFontAssetPtr::consoleInit()
{
   Parent::consoleInit();

   ConsoleBaseType::getType(TypeFontAssetPtr)->setInspectorFieldType("GuiInspectorTypeFontAssetPtr");
}

//////////////////////////////////////////////////////////////////////////
// TypeParticleAssetPtr GuiInspectorField Class
//////////////////////////////////////////////////////////////////////////
IMPLEMENT_CONOBJECT(GuiInspectorTypeParticleAssetPtr);

GuiInspectorTypeParticleAssetPtr::GuiInspectorTypeParticleAssetPtr()
{
   mAssetType = StringTable->insert("ParticleAsset");
}

void GuiInspectorTypeParticleAssetPtr::consoleInit()
{
   Parent::consoleInit();

   ConsoleBaseType::getType(TypeParticleAssetPtr)->setInspectorFieldType("GuiInspectorTypeParticleAssetPtr");
}

