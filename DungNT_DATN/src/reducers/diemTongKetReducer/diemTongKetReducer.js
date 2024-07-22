import { createSlice } from "@reduxjs/toolkit";
import { diemtongketservice } from "../../services/diemTongKetService/diemTongKetService";

export const diemTongKetSlice = createSlice({
    name: "diemtongket",
    initialState: {
        diemTongKet: {},
        typeSearch: 0,
        pageNumber: 1,
        pageSize: 10,
        kyHoc: "",
        namHoc: "",
        errorMessage: "",
        listMonTongKet: [],
        monTongKet: "",
        listKyHoc: []
    },
    reducers: {
        setDiemTongKet: (state, action) => {
            state.diemTongKet = action.payload;
        },
        setAdvanceSearchDiemTongKet: (state, action) => {
            state.pageNumber = action.payload.pageNumber;
            state.pageSize = action.payload.pageSize;
        },
        setTypeSearch: (state, action) => {
            state.typeSearch = action.payload;
        },
        setKyHoc: (state, action) => {
            state.kyHoc = action.payload;
        },
        setNamHocTongKet: (state, action) => {
            state.namHoc = action.payload;
        },
        setErrorMessage: (state, action) => {
            state.errorMessage = action.payload;
        },
        setListMonTongKet: (state, action) => {
            state.listMonTongKet = action.payload;
        },
        setMonTongKet: (state, action) => {
            state.monTongKet = action.payload;
        },
        setListKyHoc: (state, action) => {
            state.listKyHoc = action.payload;
        }
    },
});

export const getDiemTongKetAction =
    (username, kyHocId, monTongKetId) => async (dispatch) => {
        try {
            const res = await diemtongketservice.getDiemTongKet(username, kyHocId, monTongKetId);
            if (res.status === 200) {
                dispatch(setDiemTongKet(res.data.value));
                dispatch(setKyHoc(res.data.value?.kyHoc?.id));
                dispatch(setNamHocTongKet(res.data.value?.kyHoc?.namHoc));
                dispatch(setErrorMessage(""));
                dispatch(setMonTongKet(monTongKetId));
            }
        } catch (err) {
            dispatch(setMonTongKet(null));
            dispatch(setErrorMessage(err.response.data.Message));
        }
    };

export const getListMonTongKetAction = () => async (dispatch) => {
    try {
        const res = await diemtongketservice.getListMonTongKet();
        if (res.status === 200) {
            let listSelect = res.data?.value?.map((item) => {
                return {
                    value: item.id,
                    label: item.tenMon,
                };
            });

            dispatch(
                setListMonTongKet([...listSelect, { value: "", label: "Tổng kết" }])
            );
        }
    } catch (err) {
        console.log();
    }
};

export const getListKyHocAction = (namHoc) => async (dispatch) => {
    try {
        const res = await diemtongketservice.getListKyHoc(namHoc);
        if (res.status === 200) {
            let listSelect = res.data?.value?.map((item) => {
                return {
                    value: item.id,
                    label: item.tenKyHoc,
                };
            });

            dispatch(
                setListKyHoc(listSelect)
            );
        }
    } catch (err) {
        console.log();
    }
};

export const {
    setDiemTongKet,
    setAdvanceSearchDiemTongKet,
    setTypeSearch,
    setKyHoc,
    setNamHocTongKet,
    setErrorMessage,
    setListMonTongKet,
    setMonTongKet,
    setListKyHoc
} = diemTongKetSlice.actions;
export const diemTongKetState = (state) => state.diemtongket;
export default diemTongKetSlice.reducer;
