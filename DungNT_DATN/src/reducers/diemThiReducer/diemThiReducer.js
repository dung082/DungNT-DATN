import { createSlice } from "@reduxjs/toolkit";
import { dantocservice } from "../../services/danTocService/danTocService";
import { diemthiservice } from "../../services/diemThiService/DiemThiService";
import { act } from "react";
import { getListKyThiAction } from "../kyThiReducer/kyThiReducer";
import { openWarning } from "../../templates/notification";

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

export const {
  setDiemThi,
  setAdvanceSearchDiemThi,
  setTypeSearch,
  setKyThi,
  setNamHoc,
  setErrorMessage,
  setListMonThi,
  setMonThi,
  setListResponse
} = diemThiSlice.actions;
export const diemThiState = (state) => state.diemthi;
export default diemThiSlice.reducer;
