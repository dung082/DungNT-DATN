import { Button, Input, Select } from "antd"
import { useEffect, useState } from "react"
import { infoState, setKyThi, setLop, setMonThi, setNamHoc } from "../../../../reducers/infoReducer/infoReducer"
import { useDispatch, useSelector } from "react-redux"
import { getListKyThiAction, kyThiState } from "../../../../reducers/kyThiReducer/kyThiReducer"
import { getAllLopAction, lopState } from "../../../../reducers/lopReducer/lopReducer"
import { chiTietLopState, getListHocSinhAction, setListHsAction } from "../../../../reducers/chiTietLopReducer/chiTietLopReducer"
import dayjs from "dayjs"
import { cloneDeep } from "lodash"
import { closeDrawerAction } from "../../../../reducers/drawerReducer/drawerReducer"
import { addListDiemAction, diemThiState, getListMonThiAction, getListMonThiSelectAction } from "../../../../reducers/diemThiReducer/diemThiReducer"

export default function ThemDiemThi(props) {

    const { namHoc, lop, kythi, monthi, listResponse } = useSelector(infoState)
    const { listKyThi } = useSelector(kyThiState)
    const { listLop } = useSelector(lopState)
    const { listMonThi } = useSelector(diemThiState)
    const dispatch = useDispatch()
    const { listHocSinh } = useSelector(chiTietLopState)
    const listNamHoc = [
        {
            label: "2022-2023",
            value: "2022-2023",
        },
        {
            label: "2023-2024",
            value: "2023-2024",
        },
        {
            label: "2024-2025",
            value: "2024-2025",
        },

    ]

    return (
        <div className="pb-5">
            <div className="grid grid-cols-2">
                <div className="p-2">
                    <span>
                        Năm học
                    </span>
                    <Select
                        options={listNamHoc}
                        className="w-full"
                        value={namHoc}
                        onSelect={(e) => {
                            dispatch(setNamHoc(e))
                            dispatch(getListKyThiAction(e))
                        }}
                    />
                </div>
                <div className="p-2">
                    <span>
                        Kỳ thi
                    </span>
                    <Select
                        className="w-full"
                        options={listKyThi}
                        onSelect={(e) => {
                            dispatch(setKyThi(e))
                            dispatch(getAllLopAction())
                        }}
                        value={kythi}
                    />
                </div>
                <div className="p-2">
                    <span>Lớp học</span>
                    <Select
                        className="w-full"
                        options={listLop}
                        value={lop}
                        onSelect={(e) => {
                            dispatch(setLop(e))
                            dispatch(getListMonThiSelectAction(e))
                        }}
                    />
                </div>
                <div className="p-2">
                    <span>Môn thi</span>
                    <Select
                        className="w-full"
                        value={monthi}
                        options={listMonThi}
                        onSelect={(e) => {
                            dispatch(setMonThi(e))
                            dispatch(getListHocSinhAction(namHoc, lop))
                        }}
                    />
                </div>
            </div>
            <div className="p-2">
                <span className="font-bold text-lg">Danh sách học sinh</span>
            </div>
            <div className="grid grid-cols-4">
                <div className="p-2">Họ và tên </div>
                <div className="p-2">Giới tính </div>
                <div className="p-2"> Ngày sinh</div>
                <div className="p-2"> Điểm</div>
            </div>
            {
                listHocSinh?.map((item, index) => {

                    return (
                        <div className="grid grid-cols-4" key={index}>
                            <div className="p-2">{item?.hoTen}</div>
                            <div className="p-2">{item?.gioiTinh ? "Nữ" : "Nam"}</div>
                            <div className="p-2">{item?.ngaySinh && dayjs(item?.ngaySinh).format("DD/MM/YYYY")}</div>
                            <div className="p-2"><Input value={item?.diem} onChange={(e) => {
                                let lstHs = cloneDeep(listHocSinh)
                                lstHs[index].diem = e.target.value
                                dispatch(setListHsAction(lstHs))
                            }} /></div>
                        </div>
                    )
                })
            }

            {
                listResponse?.length > 0 && (
                    <div>
                        <div className=" p-5">
                            <span>Kết quả thêm điểm thi</span>
                        </div>
                        <div className="grid grid-cols-4">
                            <div className="p-2">Họ và tên </div>
                            <div className="p-2">Giới tính </div>
                            <div className="p-2"> Ngày sinh</div>
                            <div className="p-2"> Điểm</div>
                            <div className="p-2"> Kết quả</div>
                        </div>
                        {
                            listResponse?.map((item, index) => {
                                <div className="grid grid-cols-4" key={index}>
                                    <div className="p-2">{item?.hoTen}</div>
                                    <div className="p-2">{item?.gioiTinh ? "Nữ" : "Nam"}</div>
                                    <div className="p-2">{item?.ngaySinh && dayjs(item?.ngaySinh).format("DD/MM/YYYY")}</div>
                                    <div className="p-2"> {item?.diem}</div>
                                    <div className="p-2"> {item?.Message}</div>
                                </div>
                            })
                        }
                    </div>
                )
            }
            <div className="text-center">
                <Button onClick={() => {
                    dispatch(closeDrawerAction())
                }}>Hủy</Button>
                <Button className="ml-2" type="primary" onClick={() => {
                    const data = {
                        kyThiId: kythi,
                        lopId: lop,
                        monThiId: monthi,
                        listDiemThi: listHocSinh?.map(i => {
                            return {
                                username: i?.username,
                                diem: i?.diem
                            }
                        })
                    }

                    dispatch(addListDiemAction(data))
                }}>Thêm điểm</Button>
            </div>
        </div>
    )
}