import { createSlice } from "@reduxjs/toolkit";
import { thongbaoservice } from "../../services/thongBaoService/thongBaoService";
import { openNotification } from "../../templates/notification";

export const thongBaoSlice = createSlice({
    name: "thongbao",
    initialState: {
        listThongBao: [],
        thongBaoChuaXem: 0,
        isOpen: false
    },
    reducers: {
        setListThongBao: (state, action) => {
            state.listThongBao = action.payload;
        },
        setThongBaoChuaXem: (state, action) => {
            state.thongBaoChuaXem = action.payload;
        },
        setOpenPopoverThongBao: (state, action) => {
            state.isOpen = action.payload
        }
    },
});
export const getListThongBaoAction = (username) => async (dispatch) => {
    try {
        const response = await thongbaoservice.getThongBao(username);
        if (response.status === 200) {
            dispatch(setListThongBao(response.data.value));
            const tbcx = response.data.value?.filter(i => i.status === 0)?.length;
            dispatch(setThongBaoChuaXem(tbcx))
        }
    } catch (err) {
        console.log(err);
    }
};

export const capNhatTrangThaiAction = (thongBaoId, username) => async (dispatch) => {
    try {
        const response = await thongbaoservice.xacNhanDaXem(thongBaoId);
        if (response.status === 200) {
            dispatch(getListThongBaoAction(username))
        }
    } catch (err) {
        console.log(err);
    }
};

export const capNhatTrangThaiListThongBaoAction = (listThongBaoId, username) => async (dispatch) => {
    try {
        const response = await thongbaoservice.xacNhanDaXemListThongBao(listThongBaoId);
        if (response.status === 200) {
            dispatch(getListThongBaoAction(username))
            openNotification("Thành công", "Xác nhận đọc hết thông báo thành công")
        }
    } catch (err) {
        console.log(err);
    }
};

export const { setListThongBao, setThongBaoChuaXem, setOpenPopoverThongBao } = thongBaoSlice.actions;
export const thongbaoState = (state) => state.thongbao;
export default thongBaoSlice.reducer;
