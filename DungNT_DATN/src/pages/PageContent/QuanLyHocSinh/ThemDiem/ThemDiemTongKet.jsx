import { Button, Input, Select } from 'antd'
import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { infoState, setKyHoc, setLop, setMonTongKet, setNamHoc } from '../../../../reducers/infoReducer/infoReducer'
import { diemTongKetState, getListKyHocAction, getListMonTongKetAction, getListMonTongKetAddAction, setListKyHoc, setListResponse, themListDiemAction } from '../../../../reducers/diemTongKetReducer/diemTongKetReducer'
import { getAllLopAction, lopState } from '../../../../reducers/lopReducer/lopReducer'
import { chiTietLopState, getListHocSinhAction, setListHsAction } from '../../../../reducers/chiTietLopReducer/chiTietLopReducer'
import dayjs from 'dayjs'
import { cloneDeep } from 'lodash'
import { closeDrawerAction } from '../../../../reducers/drawerReducer/drawerReducer'
export default function ThemDiemTongKet(props) {

    const { namHoc, lop, kyhoc, montongket } = useSelector(infoState)
    const { listKyHoc, listMonTongKet, listResponse } = useSelector(diemTongKetState)
    const dispatch = useDispatch()
    const { listLop } = useSelector(lopState)
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


    useEffect(() => {
        dispatch(setListHsAction([]))
        dispatch(setListKyHoc([]))
        dispatch(setKyHoc(""))
        dispatch(setLop(""))
        dispatch(setNamHoc(""))
        dispatch(setMonTongKet(""))
        dispatch(setListResponse([]))
    }, [])

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
                            dispatch(getListKyHocAction(e))
                        }}
                    />
                </div>
                <div className="p-2">
                    <span>
                        Kỳ học
                    </span>
                    <Select
                        className="w-full"
                        options={listKyHoc}
                        onSelect={(e) => {
                            dispatch(setKyHoc(e))
                            dispatch(getAllLopAction())
                        }}
                        value={kyhoc}
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
                            dispatch(getListMonTongKetAddAction())
                            dispatch(getListHocSinhAction(namHoc, e))
                        }}
                    />
                </div>
                <div className="p-2">
                    <span>Môn thi</span>
                    <Select
                        className="w-full"
                        value={montongket}
                        options={listMonTongKet}
                        onSelect={(e) => {
                            dispatch(setMonTongKet(e))
                        }}
                    />
                </div>
            </div>
            {
                listHocSinh?.length > 0 && (
                    <div>
                        <div className="p-2">
                            <span className="font-bold text-lg">Danh sách học sinh</span>
                        </div>
                        <div className="grid grid-cols-4">
                            <div className="p-2 font-bold bg-[#8bbce8] ">Họ và tên </div>
                            <div className="p-2 font-bold bg-[#8bbce8] ">Giới tính </div>
                            <div className="p-2 font-bold bg-[#8bbce8] "> Ngày sinh</div>
                            <div className="p-2 font-bold bg-[#8bbce8] "> Điểm</div>
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
                    </div>
                )
            }

            {
                listResponse?.length > 0 && (
                    <div>
                        <div className=" p-2">
                            <span className="font-bold text-lg">Kết quả thêm điểm thi</span>
                        </div>
                        <div className="grid grid-cols-5">
                            <div className="p-2 font-bold bg-[#8bbce8] ">Họ và tên </div>
                            <div className="p-2 font-bold bg-[#8bbce8] ">Giới tính </div>
                            <div className="p-2 font-bold bg-[#8bbce8] "> Ngày sinh</div>
                            <div className="p-2 font-bold bg-[#8bbce8] "> Điểm</div>
                            <div className="p-2 font-bold bg-[#8bbce8] "> Kết quả</div>
                        </div>
                        {
                            listResponse?.map((item, index) => {
                                return (
                                    <div className="grid grid-cols-5" key={index}>
                                        <div className="p-2">{item?.hoTen}</div>
                                        <div className="p-2">{item?.gioiTinh ? "Nữ" : "Nam"}</div>
                                        <div className="p-2">{item?.ngaySinh && dayjs(item?.ngaySinh).format("DD/MM/YYYY")}</div>
                                        <div className="p-2"> {item?.diem}</div>
                                        <div className="p-2"> {item?.result}</div>
                                    </div>
                                )
                            })
                        }
                    </div>
                )
            }
            <div className="text-center mt-3">
                <Button onClick={() => {
                    dispatch(closeDrawerAction())
                }}>Hủy</Button>
                <Button className="ml-2" type="primary" onClick={() => {
                    const data = {
                        hocKyId: kyhoc,
                        lopId: lop,
                        monTongKetId: montongket,
                        listDT: listHocSinh?.map(i => {
                            return {
                                username: i?.username,
                                diem: parseFloat(i?.diem)
                            }
                        })
                    }

                    dispatch(themListDiemAction(data))
                }}>Thêm điểm</Button>
            </div>
        </div>
    )
}