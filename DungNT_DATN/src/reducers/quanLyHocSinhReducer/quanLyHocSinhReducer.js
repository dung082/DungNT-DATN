import { createSlice } from "@reduxjs/toolkit";
import { kythiservice } from "../../services/kyThiService/kyThiService";
import { diemtongketservice } from "../../services/diemTongKetService/diemTongKetService";
import { openWarning } from "../../templates/notification";
import { diemthiservice } from "../../services/diemThiService/DiemThiService";

export const quanLyHocSinhSlice = createSlice({
    name: "quanlyhocsinh",
    initialState: {
        username: "",
        namhoc: "",
        kyhoc: "",
        kythi: "",
        monhoc: "",
        diemthi: 0,
        listKyHoc: [],
        listKyThi: [],
        listMon: [],
        diemObject: {}
    },
    reducers: {
        setUsername: (state, action) => {
            state.username = action.payload
        },
        setNamHoc: (state, action) => {
            state.namhoc = action.payload
        },
        setKyHoc: (state, action) => {
            state.kyhoc = action.payload
        },
        setKyThi: (state, action) => {
            state.kythi = action.payload
        },
        setMonHoc: (state, action) => {
            state.monhoc = action.payload
        },
        setListKyHoc: (state, action) => {
            state.listKyHoc = action.payload
        },
        setListKyThi: (state, action) => {
            state.listKyThi = action.payload
        },
        setListMonHoc: (state, action) => {
            state.listMon = action.payload
        },
        setDiem: (state, action) => {
            state.diem = action.payload
        },
        setDiemObject: (state, action) => {
            state.diemObject = action.payload
        }
    },
});

export const getListKyThiAction = (namHoc) => async (dispatch) => {
    try {
        const res = await kythiservice.getKyThiTheoNam(namHoc);
        if (res.status === 200) {
            const list = res.data?.value?.map((item) => {
                return {
                    value: item.id,
                    label: item.tenKyThi
                }
            })
            dispatch(setListKyThi(list))
        }
    }
    catch (err) {
        console.log(err);
    }
}

export const getListKyHocAction = (namHoc) => async (dispatch) => {
    try {
        const res = await diemtongketservice.getListKyHoc(namHoc);
        if (res.status === 200) {
            const list = res.data?.value?.map((item) => {
                return {
                    value: item.id,
                    label: item.tenKyHoc,
                }
            })
            dispatch(setListKyHoc(list))
        }
    }
    catch (err) {
        console.log(err);
    }
}


export const getListMonThiAction = (lopId) => async (dispatch) => {
    try {
        const res = await diemtongketservice.getListMonThi(lopId);
        if (res.status === 200) {
            const list = res.data?.value?.map((item) => {
                return {
                    value: item.id,
                    label: item.tenMonThi,
                }
            })
            dispatch(setListMonHoc([...list]))
        }
    }
    catch (err) {
        console.log(err);
    }
}

export const getListMonThiByUserAction = (username, namhoc) => async (dispatch) => {
    try {
        const res = await diemthiservice.getMonThiByUser(username, namhoc);
        if (res.status === 200) {
            const list = res.data?.value?.map((item) => {
                return {
                    value: item.id,
                    label: item.tenMonThi,
                }
            })
            dispatch(setListMonHoc([...list]))
        }
    }
    catch (err) {
        openWarning("Thất bại", err?.response?.data?.Message ? err?.response?.data?.Message : "Không thể lấy môn thi do học sinh không có lớp trong năm học đã chọn")

    }
}

export const getListMonTongKetAction = () => async (dispatch) => {
    try {
        const res = await diemtongketservice.getListMonTongKet();
        if (res.status === 200) {
            const list = res.data?.value?.map((item) => {
                return {
                    value: item.id,
                    label: item.tenMon,
                }
            })
            dispatch(setListMonHoc([...list]))
        }
    }
    catch (err) {
        console.log(err);
    }
}

export const getDiemTongKetUserAction = (username, monTongKetId, kyHocId) => async (dispatch) => {
    try {
        const res = await diemtongketservice.layDiemTongKetTheoUser(username, monTongKetId, kyHocId)
        if (res.status === 200) {
            if (res.data.value !== null) {
                dispatch(setDiem(res.data.value.diem))
                dispatch(setDiemObject(res.data.value))
            }
            else {
                dispatch(setDiem(0))
                openWarning("Thất bại", "Chưa có điểm thi của học sinh")
            }
        }
    }
    catch (err) {
        dispatch(setDiem(0))
        openWarning("Thất bại", err?.response?.data?.Message ? err?.response?.data?.Message : "Chưa có điểm thi của học sinh")
    }
}

export const getDiemThiUserAction = (username, monThiId, kyThiId) => async (dispatch) => {
    try {
        const res = await diemthiservice.layDiemThiTheoUser(username, monThiId, kyThiId)
        if (res.status === 200) {
            if (res.data.value !== null) {
                dispatch(setDiem(res.data.value.diem))
                dispatch(setDiemObject(res.data.value))
            }
            else {
                dispatch(setDiem(0))
                openWarning("Thất bại", "Chưa có điểm thi của học sinh")
            }
        }
    }
    catch (err) {
        dispatch(setDiem(0))
        openWarning("Thất bại", err?.response?.data?.Message ? err?.response?.data?.Message : "Chưa có điểm thi của học sinh")
    }
}

export const {
    setUsername,
    setNamHoc,
    setKyThi,
    setKyHoc,
    setMonHoc,
    setListKyHoc,
    setListKyThi,
    setListMonHoc,
    setDiem,
    setDiemObject
} = quanLyHocSinhSlice.actions;
export const quanLyHocSinhState = (state) => state.quanlyhocsinh;
export default quanLyHocSinhSlice.reducer;
