import { createSlice } from "@reduxjs/toolkit";
import { dantocservice } from "../../services/danTocService/danTocService";
import { diemthiservice } from "../../services/diemThiService/DiemThiService";
import { act } from "react";
import { getListKyThiAction } from "../kyThiReducer/kyThiReducer";
import { openNotification, openWarning } from "../../templates/notification";
import { closeModalAction } from "../modalReducer/modalReducer";
import { closeDrawerAction } from "../drawerReducer/drawerReducer";

export const diemThiSlice = createSlice({
  name: "diemthi",
  initialState: {
    diemThi: {},
    typeSearch: 0,
    pageNumber: 1,
    pageSize: 10,
    kyThi: "",
    namHoc: "",
    errorMessage: "",
    listMonThi: [],
    monThi: "",
    listResponse: [],
    listMonThiPK: []
  },
  reducers: {
    setDiemThi: (state, action) => {
      state.diemThi = action.payload;
    },
    setAdvanceSearchDiemThi: (state, action) => {
      state.pageNumber = action.payload.pageNumber;
      state.pageSize = action.payload.pageSize;
    },
    setTypeSearch: (state, action) => {
      state.typeSearch = action.payload;
    },
    setKyThi: (state, action) => {
      state.kyThi = action.payload;
    },
    setNamHoc: (state, action) => {
      state.namHoc = action.payload;
    },
    setErrorMessage: (state, action) => {
      state.errorMessage = action.payload;
    },
    setListMonThi: (state, action) => {
      state.listMonThi = action.payload;
    },
    setMonThi: (state, action) => {
      state.monThi = action.payload;
    },
    setListResponse: (state, action) => {
      state.listResponse = action.payload;
    },
    setListMonThiPK: (state, action) => {
      state.listMonThiPK = action.payload;
    }
  },
});

export const getDiemThiAction =
  (type, username, kyThiId, monThiId) => async (dispatch) => {
    try {
      const res = await diemthiservice.getDiemThi(
        type,
        username,
        kyThiId,
        monThiId
      );
      if (res.status === 200) {
        dispatch(setDiemThi(res.data.value));
        dispatch(setKyThi(res.data.value?.kyThi?.id));
        dispatch(setNamHoc(res.data.value?.kyHoc?.namHoc));
        dispatch(setErrorMessage(""));
        dispatch(setTypeSearch(type));
        dispatch(setMonThi(monThiId));
        dispatch(getListKyThiAction(res.data.value?.kyHoc?.namHoc));
      }
    } catch (err) {
      dispatch(setDiemThi(null));
      dispatch(setTypeSearch(type));
      dispatch(setErrorMessage(err.response.data.Message));
    }
  };

export const getListMonThiAction = (khoiHoc) => async (dispatch) => {
  try {
    const res = await diemthiservice.getListMonThi(khoiHoc);
    if (res.status === 200) {
      let listSelect = res.data?.value?.map((item) => {
        return {
          value: item.id,
          label: item.tenMonThi,
        };
      });

      dispatch(
        setListMonThi([...listSelect, { value: "", label: "Tổng kết" }])
      );
    }
  } catch (err) {
    console.log();
  }
};

export const getListMonThiPKAction = (khoiHoc) => async (dispatch) => {
  try {
    const res = await diemthiservice.getListMonThi(khoiHoc);
    if (res.status === 200) {
      let listSelect = res.data?.value?.map((item) => {
        return {
          ...item,
          check: false
        };
      });

      dispatch(
        setListMonThiPK([...listSelect])
      );
    }
  } catch (err) {
    console.log();
  }
};

export const getListMonThiSelectAction = (khoiHoc) => async (dispatch) => {
  try {
    const res = await diemthiservice.getListMonThi(khoiHoc);
    if (res.status === 200) {
      let listSelect = res.data?.value?.map((item) => {
        return {
          value: item.id,
          label: item.tenMonThi,
        };
      });

      dispatch(
        setListMonThi(listSelect)
      );
    }
  } catch (err) {
    console.log();
  }
};

export const addListDiemAction = (data) => async (dispatch) => {
  try {
    const res = await diemthiservice.themListDiemThi(data);
    if (res.status === 200) {
      let result = res?.data?.value?.map(item => {
        return {
          username: item?.username,
          hoTen: item?.hoTen,
          ngaySinh: item?.ngaySinh,
          diem: item?.diem,
          result: item?.message
        }
      })

      dispatch(setListResponse(result))
    }
  }
  catch (err) {
    openWarning("Thất bại", err?.response?.data?.Message)
  }
}

export const phucKhaoDiemThiAction = (username, namHoc, kyThiId, listMonThiId) => async (dispatch) => {
  try {
    const res = await diemthiservice.phucKhaoDiemThi(username, namHoc, kyThiId, listMonThiId)
    if (res.status === 200) {
      openNotification("Thành công", "Phúc khảo điểm thành công")
      dispatch(closeModalAction())
    }
  }
  catch (err) {
    openWarning("Thất bại", err?.response?.data?.Message ? err?.response?.data?.Message : "Không thể phúc khảo điểm")

  }
}

export const suaDiemThiAction = (type, diemThiId, diem) => async (dispatch) => {
  try {
    const res = await diemthiservice.suaDiemThi(type, diemThiId, diem)
    if (res.status === 200) {
      openNotification("Thành công", "Sửa điểm cho học sinh thành công");
      dispatch(closeDrawerAction())
    }
  }
  catch (err) {
    openWarning("Thất bại", err?.response?.data?.Message ? err?.response?.data?.Message : "Không thể phúc khảo điểm")

  }
}

export const {
  setDiemThi,
  setAdvanceSearchDiemThi,
  setTypeSearch,
  setKyThi,
  setNamHoc,
  setErrorMessage,
  setListMonThi,
  setMonThi,
  setListResponse,
  setListMonThiPK
} = diemThiSlice.actions;
export const diemThiState = (state) => state.diemthi;
export default diemThiSlice.reducer;
