import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  chuongTrinhHocState,
  getListChuongTrinhHocAction,
} from "../../../reducers/chuongTrinhHocReducer/chuongTrinhHocReducer";
import {
  getListKhoiAction,
  khoiState,
} from "../../../reducers/khoiReducer/khoiReducer";
import { Select, Table } from "antd";
import { CHUONG_TRINH_KHUNG_TABLE_CONFIG } from "../../../templates/tableConfig";
export default function ChuongTrinhHoc(props) {
  const { listKhoiSelect } = useSelector(khoiState);
  const { listTruongTrinhHoc } = useSelector(chuongTrinhHocState);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getListKhoiAction());
    dispatch(getListChuongTrinhHocAction(""));
  }, []);
  return (
    <>
      <div className="p-5">
        <Select
          options={listKhoiSelect}
          className="w-[200px]"
          placeholder="--Chọn khối--"
          onChange={() => {
            console.log(listTruongTrinhHoc);
          }}
        />
      </div>
      <Table
        columns={CHUONG_TRINH_KHUNG_TABLE_CONFIG}
        dataSource={listTruongTrinhHoc}
      />
    </>
  );
}
