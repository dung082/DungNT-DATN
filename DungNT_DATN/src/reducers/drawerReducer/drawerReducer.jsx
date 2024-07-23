import { createSlice } from "@reduxjs/toolkit";
import { Component } from "react";

export const drawerSlice = createSlice({
    name: "drawer",
    initialState: {
        visiable: false,
        title: "",
        DrawerComponent: <></>,
        width: 800
    },
    reducers: {
        openDrawerAction: (state, action) => {
            state.visiable = true
            state.title = action.payload.title
            state.DrawerComponent = action.payload.DrawerComponent
            state.width = action.payload.width ? action.payload.width : 800
        }
        ,
        closeDrawerAction: (state) => {
            state.title = ""
            state.visiable = false
            state.DrawerComponent = <></>
        }
    },
});

export const { openDrawerAction, closeDrawerAction } = drawerSlice.actions;
export const stateDrawer = (state) => state.drawer;
export default drawerSlice.reducer;