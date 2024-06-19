import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  chuongTrinhHocState,
  getListChuongTrinhHocAction,
  setAdvanceSearch,
} from "../../../reducers/chuongTrinhHocReducer/chuongTrinhHocReducer";
import {
  getListKhoiAction,
  khoiState,
} from "../../../reducers/khoiReducer/khoiReducer";
import { Select, Table } from "antd";
import { CHUONG_TRINH_KHUNG_TABLE_CONFIG } from "../../../templates/tableConfig";
import TableComponent from "../../../assets/Component/TableComponent";
import { globalState } from "../../../reducers/globalReducer/globalReducer";
export default function ChuongTrinhHoc(props) {
  const { listKhoiSelect } = useSelector(khoiState);
  const { listTruongTrinhHoc, pageNumber, pageSize } =
    useSelector(chuongTrinhHocState);
  const { userInfo } = useSelector(globalState);
  const dispatch = useDispatch();

  const [defaultKhoi, setDefaultKhoi] = useState();

  const lstKhoiSelect = [
    {
      value : 10,
      label : "Khối 10"
    },
    {
      value : 11,
      label : "Khối 11"
    },
    {
      value : 12,
      label : "Khối 12"
    },
  ]
  useEffect(() => {
    dispatch(getListKhoiAction());
    dispatch(getListChuongTrinhHocAction(10));
  }, []);
  return (
    <>
      <div className="p-5">
        <div className=" bottem-border-title pb-2">
          <div className="flex justify-between">
            <div>
              <span className="font-bold text-xl">
                Chương trình học theo khối
              </span>
            </div>
          </div>
        </div>
        <div className="flex justify-end mt-3">
          <Select
            // allowClear
            defaultValue={10}
            options={lstKhoiSelect}
            className="w-[200px]"
            placeholder="--Chọn khối--"
            onChange={(e) => {
              if (typeof e === "undefined") {
                dispatch(getListChuongTrinhHocAction(10));
              } else {
                dispatch(getListChuongTrinhHocAction(e));
              }
            }}
          />
        </div>
        <TableComponent
          className="mt-3"
          ColumnConfig={CHUONG_TRINH_KHUNG_TABLE_CONFIG}
          DataSource={listTruongTrinhHoc}
          CurrentPage={pageNumber}
          CurrentPageSize={pageSize}
          OnPageChange={(pageNumber, pageSize) => {
            dispatch(
              setAdvanceSearch({ pageNumber: pageNumber, pageSize: pageSize })
            );
          }}
        />
      </div>
    </>
  );
}
