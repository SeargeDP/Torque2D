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

#ifndef _GUIEDITCTRL_H_
#define _GUIEDITCTRL_H_

#include "gui/guiControl.h"
#include "collection/undo.h"

class GuiEditCtrl : public GuiControl
{
   typedef GuiControl Parent;

   Vector<GuiControl *> mSelectedControls; //A list of selected controls.
   GuiControl*          mCurrentAddSet; //The curent container (sim set) that is being worked in (controls are added to). Changed by right clicking.
   GuiControl*          mEditorRoot; //The editor root which attempts to simulate the canvas. This can be the add set, but should never be selected.
   Point2I              mLastMousePos;
   Point2I              mSelectionAnchor;
   Point2I              mGridSnap;
   bool					mUseGridSnap;
   Point2I				   mDragBeginPoint;
   Vector<Point2I>		mDragBeginPoints;
   GuiControl*			mMouseLockedEditCtrl;

   // Undo
   UndoManager          mUndoManager;
   SimGroup             mTrash;
   SimSet               mSelectedSet;
   
   // Sizing Cursors
   GuiCursor*        mDefaultCursor;
   GuiCursor*        mLeftRightCursor;
   GuiCursor*        mUpDownCursor;
   GuiCursor*        mNWSECursor;
   GuiCursor*        mNESWCursor;
   GuiCursor*        mMoveCursor;

   enum mouseModes { Selecting, MovingSelection, SizingSelection, DragSelecting };
   enum sizingModes { sizingNone = 0, sizingLeft = 1, sizingRight = 2, sizingTop = 4, sizingBottom = 8 };

   mouseModes             mMouseDownMode;
   sizingModes             mSizingMode;

   // private methods
   void updateSelectedSet();

  public:
   GuiEditCtrl();
   DECLARE_CONOBJECT(GuiEditCtrl);

   bool onWake();
   void onSleep();

   void select(GuiControl *ctrl);
   void setRoot(GuiControl *ctrl);
   GuiControl* getRoot() { return mEditorRoot; }
   void setEditMode(bool value);
   S32 getSizingHitKnobs(const Point2I &pt, const RectI &box);
   void getDragRect(RectI &b);
   void drawNut(const Point2I &nut, ColorI &outlineColor, ColorI &nutColor);
   void drawControlDecoration(GuiControl* ctrl, RectI &box, ColorI &outlineColor, ColorI &nutColor);
   void drawDashedLine(const F32& dashLength, const S32& x1, const S32& y1, const S32& x2, const S32& y2, ColorI& color);
   void drawTargetLines(const S32& lx, const S32& ty, ColorI& weakColor, const S32& by, const S32& rx, ColorI& strongColor);
   void drawNuts(S32& lx, S32& ty, S32& rx, S32& by, ColorI& outlineColor, ColorI& nutColor, const S32& cy, const S32& cx);
   void onPreRender();
   void onRender(Point2I offset, const RectI &updateRect);
   void addNewControl(GuiControl *ctrl);
   bool selectionContains(GuiControl *ctrl);
   void setCurrentAddSet(GuiControl *ctrl, bool clearSelection = true);
   const GuiControl* getCurrentAddSet() const;
   void setSelection(GuiControl *ctrl);

   // Undo Access
   void undo();
   void redo();
   UndoManager& getUndoManager() { return mUndoManager; }

   // When a control is changed by the inspector
   void controlInspectPreApply(GuiControl* object);
   void controlInspectPostApply(GuiControl* object);

   // Sizing Cursors
   bool initCursors();
   void getCursor(GuiCursor *&cursor, bool &showCursor, const GuiEvent &lastGuiEvent);


   const Vector<GuiControl *> *getSelected() const { return &mSelectedControls; }
   SimSet& getSelectedSet() { updateSelectedSet(); return mSelectedSet; }
   const SimGroup& getTrash() { return mTrash; }
   const GuiControl* getAddSet() const { return mCurrentAddSet; };

   bool onKeyDown(const GuiEvent &event);
   void onTouchDown(const GuiEvent &event);
   void onTouchUp(const GuiEvent &event);
   void onTouchDragged(const GuiEvent &event);
   void onRightMouseDown(const GuiEvent &event);

   virtual bool onAdd();
   virtual void onRemove();

   enum Justification {
      JUSTIFY_LEFT,
      JUSTIFY_CENTER,
      JUSTIFY_RIGHT,
      JUSTIFY_TOP,
      JUSTIFY_BOTTOM,
      SPACING_VERTICAL,
      SPACING_HORIZONTAL
   };

   void justifySelection( Justification j);
   void moveSelection(const Point2I &delta);
   void moveAndSnapSelection(const Point2I &delta);
   void saveSelection(const char *filename);
   void loadSelection(const char *filename);
   void addSelection(S32 id);
   void removeSelection(S32 id);
   void deleteSelection();
   void clearSelection();
   void selectAll();
   void bringToFront();
   void pushToBack();
   void setSnapToGrid(U32 gridsize);
   bool hasSnapToGrid() { return mUseGridSnap; }
   S32 getGridSize() { return mGridSnap.x; }
   void moveSelectionToCtrl(GuiControl*);
   ColorI getEditorColor() { return mProfile->getFillColor(DisabledState); }

   //Editor Mouse Locking
   bool editIsMouseLocked(GuiControl* ctrl) { return ctrl == mMouseLockedEditCtrl; }
   void editMouseLock(GuiControl* ctrl) { mMouseLockedEditCtrl = ctrl; }
   void editMouseUnlock() { mMouseLockedEditCtrl = nullptr; }
};

#endif //_GUI_EDIT_CTRL_H
