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

#ifndef _GUIARRAYCTRL_H_
#define _GUIARRAYCTRL_H_

#ifndef _GUITYPES_H_
#include "gui/guiTypes.h"
#endif
#ifndef _GUITEXTCTRL_H_
#include "gui/guiTextCtrl.h"
#endif

/// Renders a grid of cells.
class GuiArrayCtrl : public GuiControl
{
   typedef GuiControl Parent;

protected:

   Point2I mSize;
   Point2I mCellSize;
   Point2I mSelectedCell;
   Point2I mMouseOverCell;

   Resource<GFont> mFont;

   bool cellSelected(Point2I cell);
   virtual void onCellSelected(Point2I cell);
   virtual void onCellHighlighted(Point2I cell);
public:

   GuiArrayCtrl();

   bool onWake();
   void onSleep();

   /// @name Array attribute methods
   /// @{
   Point2I getSize() { return mSize; }
   virtual void setSize(Point2I size);
   void getScrollDimensions(S32 &cell_size, S32 &num_cells);
   /// @}

   /// @name Selected cell methods
   /// @{
   void setSelectedCell(Point2I cell);
   void deselectCells() { mSelectedCell.set(-1,-1); }
   Point2I getSelectedCell();
   void scrollSelectionVisible();
   void scrollCellVisible(Point2I cell);
   /// @}

   /// @name Rendering methods
   /// @{
   virtual void onRenderCell(Point2I offset, Point2I cell, bool selected, bool mouseOver) = 0;
   void onRender(Point2I offset, const RectI &updateRect);
   /// @}

   /// @name Mouse input methods
   /// @{
   void onTouchDown(const GuiEvent &event);
   void onTouchMove(const GuiEvent &event);
   void onTouchDragged(const GuiEvent &event);
   void onTouchEnter(const GuiEvent &event);
   void onTouchLeave(const GuiEvent &event);
   bool onKeyDown(const GuiEvent &event);
   void onRightMouseDown(const GuiEvent &event);
   /// @}
};

#endif //_GUI_ARRAY_CTRL_H
