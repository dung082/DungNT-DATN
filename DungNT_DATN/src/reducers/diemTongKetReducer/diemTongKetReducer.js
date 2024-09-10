import { createSlice } from "@reduxjs/toolkit";
import { diemtongketservice } from "../../services/diemTongKetService/diemTongKetService";
import { openNotification, openWarning } from "../../templates/notification";
import { closeModalAction } from "../modalReducer/modalReducer";
import { closeDrawerAction } from "../drawerReducer/drawerReducer";

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
    listKyHoc: [],
    listResponse: [],
    listMonTongKetPK: []
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
    },
    setListResponse: (state, action) => {
      state.listResponse = action.payload;
    },
    setListMonTongKetPK: (state, action) => {
      state.listMonTongKetPK = action.payload;
    }
  },
});

export const getDiemTongKetAction =
  (type, username, kyHocId, monTongKetId) => async (dispatch) => {
    try {
      const res = await diemtongketservice.getDiemTongKet(
        type,
        username,
        kyHocId,
        monTongKetId
      );
      if (res.status === 200) {
        dispatch(setDiemTongKet(res.data.value));
        dispatch(setKyHoc(res.data.value?.kyHoc?.id));
        dispatch(setNamHocTongKet(res.data.value?.kyHoc?.namHoc));
        dispatch(setErrorMessage(""));
        dispatch(setMonTongKet(monTongKetId));
        dispatch(setTypeSearch(type));
        dispatch(getListKyHocAction(res.data.value?.kyHoc?.namHoc));

      }
    } catch (err) {
      dispatch(setMonTongKet(null));
      dispatch(setTypeSearch(type));
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

export const getListMonTongKetAddAction = () => async (dispatch) => {
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
        setListMonTongKet([...listSelect])
      );
    }
  } catch (err) {
    console.log();
  }
};

export const getListMonTongKetPKAction = () => async (dispatch) => {
  try {
    const res = await diemtongketservice.getListMonTongKet();
    if (res.status === 200) {
      const list = res.data?.value.map(i => {
        return {
          ...i,
          check: false,
        }
      })
      dispatch(
        setListMonTongKetPK([...list])
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

      dispatch(setListKyHoc(listSelect));
    }
  } catch (err) {
    console.log();
  }
};

export const themListDiemAction = (data) => async (dispatch) => {
  try {
    const res = await diemtongketservice.addListDiemTongKet(data);
    if (res.status === 200) {
      let result = res?.data?.value?.listRes?.map(item => {
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

export const phucKhaoDiemTongKetAction = (username, namhoc, kyHocId, listMonTongKetId) => async (dispatch) => {
  try {
    const res = await diemtongketservice.phucKhaoDiemTongKet(username, namhoc, kyHocId, listMonTongKetId)
    if (res.status === 200) {
      openNotification("Thành công", "Bạn đã phúc khảo thành công");
      dispatch(closeModalAction())
    }
  }
  catch (err) {
    openWarning("Thất bại", err?.response?.data?.Message ? err?.response?.data?.Message : "Không thể phúc khảo điểm")

  }
}

export const suaDiemTongKetAction = (type, diemTongKetId, diem) => async (dispatch) => {
  try {
    const res = await diemtongketservice.suaDiemTongKet(type, diemTongKetId, diem)
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
  setDiemTongKet,
  setAdvanceSearchDiemTongKet,
  setTypeSearch,
  setKyHoc,
  setNamHocTongKet,
  setErrorMessage,
  setListMonTongKet,
  setMonTongKet,
  setListKyHoc,
  setListResponse,
  setListMonTongKetPK
} = diemTongKetSlice.actions;
export const diemTongKetState = (state) => state.diemtongket;
export default diemTongKetSlice.reducer;
