import { createSlice } from "@reduxjs/toolkit";
import { diemdanhservice } from "../../services/diemDanhService/diemDanhService";
import { openNotification, openWarning } from "../../templates/notification";
import { closeModalAction } from "../modalReducer/modalReducer";
import { lopservice } from "../../services/lopService/lopService";
import { chitietlopservice } from "../../services/chiTietLopHocService/chiTietLopHocService";

export const diemDanhSlice = createSlice({
  name: "diemdanh",
  initialState: {
    diemDanh: {},
    listCaHoc: [],
    listDiemDanh: [],
    pageNumber: 1,
    pageSize: 10,
    namhoc: "",
    lopHoc: "",
    ngayHoc: "",
    listLopHoc: [],
    listHocSinh: [],
    cahoc: "",
  },
  reducers: {
    setDiemDanh: (state, action) => {
      state.diemDanh = action.payload;
    },
    setListCaHoc: (state, action) => {
      state.listCaHoc = action.payload;
    },
    setListDiemDanh: (state, action) => {
      state.listDiemDanh = action.payload
    },
    setAdvanceSearchDiemDanh: (state, action) => {
      state.pageNumber = action.payload.pageNumber
      state.pageSize = action.payload.pageSize
    },
    setCaHoc: (state, action) => {
      state.cahoc = action.payload
    },
    setNamHoc: (state, action) => {
      state.namhoc = action.payload
    },
    setLopHoc: (state, action) => {
      state.lopHoc = action.payload
    },
    setNgayHoc: (state, action) => {
      state.ngayHoc = action.payload
    },
    setListLopHoc: (state, action) => {
      state.listLopHoc = action.payload
    },
    setListHocSinh: (state, action) => {
      state.listHocSinh = action.payload
    }
  },
});

export const getDiemDanhAction =
  (ngay, username) => async (dispatch) => {
    try {
      const res = await diemdanhservice.getDiemDanh(ngay, username);
      if (res.status === 200) {
        dispatch(setDiemDanh(res.data.value));
      }
    } catch (err) {
      dispatch(setDiemDanh({}));
      //   dispatch(setErrorMessage(err.response.data.Message));
    }
  };

export const getListCaHocAction = () => async (dispatch) => {
  try {
    const res = await diemdanhservice.getCaHoc();
    if (res.status === 200) {
      const newList = res.data.value?.map(item => {
        return {
          label: item.tenCaHoc,
          value: item.id
        }
      })
      dispatch(setListCaHoc(newList))
    }
  }
  catch (err) {
    console.log(err);
  }
}

export const xinNghiAction = (data) => async (dispatch) => {
  try {
    const res = await diemdanhservice.addDiemDanh(data);
    if (res.status === 200) {
      openNotification("Thành công", "Nộp đơn xin nghỉ thành công");
      dispatch(getDiemDanhAction("", data?.username))
      dispatch(closeModalAction())
    }
  }
  catch (err) {
    console.log(err);
    openWarning("Thất bại", err?.response?.data?.Message)

  }

}


export const suaDiemDanhAction = (data) => async (dispatch) => {
  try {
    const res = await diemdanhservice.suaDiemDanh(data);
    if (res.status === 200) {
      openNotification("Thành công", "Sửa đơn xin nghỉ thành công");
      dispatch(getDiemDanhAction("", data?.username))
      dispatch(closeModalAction())
    }
  }
  catch (err) {
    console.log(err);
  }

}


export const xoaDiemDanhAction = (diemDanhId, username) => async (dispatch) => {
  try {
    const res = await diemdanhservice.xoaDiemDanh(diemDanhId);
    if (res.status === 200) {
      openNotification("Thành công", "Xóa đơn xin nghỉ thành công");
      dispatch(getDiemDanhAction("", username))
      dispatch(closeModalAction())

    }
  }
  catch (err) {
    console.log(err);
    openWarning("Thất bại", err?.response?.data?.Message)
  }

}

export const layDiemDanhAction = (type) => async (dispatch) => {
  try {
    const res = await diemdanhservice.LayLichDiemDanh(type);
    if (res.status === 200) {
      dispatch(setListDiemDanh(res.data.value))
    }
  }
  catch (err) {
    console.log(err);
  }

}

export const duyetDonXinNghiAction = (diemDanhId) => async (dispatch) => {
  try {
    const res = await diemdanhservice.DuyetDonXinNghi(diemDanhId);
    if (res.status === 200) {
      openNotification("Thành công", "Duyệt đơn xin nghỉ thành công");

      dispatch(layDiemDanhAction(0))
    }
  }
  catch (err) {
    openWarning("Thất bại", err?.response?.data?.Message)
  }

}

export const getListLopHocAction = () => async (dispatch) => {
  try {
    const res = await lopservice.getAllLop();
    if (res.status === 200) {
      let newList = res.data.value?.map(i => {
        return {
          label: i?.tenLop,
          value: i?.id
        }
      })
      dispatch(setListLopHoc([...newList]));
    }
  }
  catch (err) {
    console.log(err)
  }
}

export const getListHocSinhAction = (namhoc, lopId) => async (dispatch) => {
  try {
    const res = await chitietlopservice.getHSLopNamHocDiemDanh(namhoc, lopId);
    if (res.status === 200) {
      console.log(res);

      dispatch(setListHocSinh([...res.data.value]));
    }
  }
  catch (err) {
    openWarning("Thất bại", "Không thể lấy học sinh trong lớp")
  }
}

export const diemDanhListAction = (data) => async (dispatch) => {
  try {
    const res = await diemdanhservice.DiemDanhList(data);
    if (res.status === 200) {
      openNotification(
        "Thành công", "Nộp điểm danh thành công"
      )
    }
  }
  catch (err) {
    openWarning("Thất bại", err?.response?.data?.Message ? err?.response?.data?.Message : "Nộp điểm danh thất bại")

  }
}


export const {
  setDiemDanh,
  setListCaHoc,
  setListDiemDanh,
  setAdvanceSearchDiemDanh,
  setLopHoc,
  setNamHoc,
  setNgayHoc,
  setListLopHoc,
  setListHocSinh,
  setCaHoc
} = diemDanhSlice.actions;
export const diemDanhState = (state) => state.diemdanh;
export default diemDanhSlice.reducer;
