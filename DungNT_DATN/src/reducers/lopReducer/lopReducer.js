import { createSlice } from "@reduxjs/toolkit";
import { openWarning } from "../../templates/notification";
import { lichthiservice } from "../../services/lichThiService/lichThiService";
import { lopservice } from "../../services/lopService/lopService";

export const lopSlice = createSlice({
    name: "lop",
    initialState: {
        listLop: []
    },
    reducers: {
        setListLop: (state, action) => {
            state.listLop = action.payload;
        }
    },
});

export const getAllLopAction = () => async (dispatch) => {
    try {
        const res = await lopservice.getAllLop();
        if (res.status === 200) {
            const listLop = res.data.value.map(i => {
                return {
                    label: i?.tenLop,
                    value: i?.id,
                    khoi: i?.khoi
                }
            }
            )
            dispatch(setListLop(listLop))
        }
    }
    catch (err) {
        console.log(err);
    }
}

export const { setListLop } =
    lopSlice.actions;
export const lopState = (state) => state.lop;
export default lopSlice.reducer;
