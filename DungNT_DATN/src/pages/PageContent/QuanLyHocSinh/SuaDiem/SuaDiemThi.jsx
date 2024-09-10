import { Button, Checkbox, Input, Popconfirm, Select } from "antd"
import { useEffect, useState } from "react"
import { useDispatch, useSelector } from "react-redux"
import { getDiemThiUserAction, getListKyThiAction, getListMonThiAction, getListMonThiByUserAction, quanLyHocSinhState, setDiem, setDiemObject, setKyHoc, setKyThi, setListKyHoc, setListKyThi, setListMonHoc, setMonHoc, setNamHoc, setUsername } from "../../../../reducers/quanLyHocSinhReducer/quanLyHocSinhReducer"
import { suaDiemThiAction } from "../../../../reducers/diemThiReducer/diemThiReducer"

export default function SuaDiemThi(props) {
    const { username, namhoc, kyhoc, listKyHoc, kythi, listKyThi, listMon, monhoc, diemObject, diem } = useSelector(quanLyHocSinhState)
    const [type, setType] = useState(false)

    useEffect(() => {
        dispatch(setUsername(""))
        dispatch(setNamHoc(""))
        dispatch(setKyHoc(""))
        dispatch(setKyThi(""))
        dispatch(setMonHoc(""))
        dispatch(setListKyHoc([]))
        dispatch(setListKyThi([]))
        dispatch(setListMonHoc([]))
        dispatch(setDiem(0))
        dispatch(setDiemObject(null))

    }, [])
    const dispatch = useDispatch()
    const namHocOptions = [
        {
            label: "2024-2025",
            value: "2024-2025"
        },
        {
            label: "2023-2024",
            value: "2023-2024"
        },
        {
            label: "2022-2023",
            value: "2022-2023"
        },
    ]
    return (
        <div>
            <div className="grid grid-cols-2">
                <div className="p-2">
                    <span>Tài khoản người dùng</span>
                    <Input value={username} onChange={(e) => {
                        dispatch(setUsername(e.target.value))
                    }} />
                </div>

                <div className="p-2">
                    <span>Năm học</span>
                    <Select className="w-full" options={namHocOptions} value={namhoc} onChange={(e) => {
                        dispatch(setNamHoc(e))
                        dispatch(getListMonThiByUserAction(username, e))
                        dispatch(getListKyThiAction(e))
                    }} />
                </div>

                <div className="p-2">
                    <span>Kỳ thi</span>
                    <Select className="w-full" value={kythi} options={listKyThi} onChange={(e) => { dispatch(setKyThi(e)) }} />
                </div>

                <div className="p-2">
                    <span>Môn tổng kết</span>
                    <Select className="w-full" value={monhoc} options={listMon} onChange={(e) => { dispatch(setMonHoc(e)) }} />
                </div>
            </div>

            <div className="text-center mt-3">
                <Button
                    type="primary"
                    onClick={() => {
                        dispatch(getDiemThiUserAction(username, monhoc, kythi))
                    }}
                >Tra cứu</Button>
            </div>

            <div className="mt-3">
                {
                    diem ? (
                        <div>
                            <div className="grid grid-cols-2 items-end">
                                <div className="p-2">
                                    <span>Điểm tổng kết</span>
                                    <Input
                                        value={diem}
                                        onChange={(e) => {
                                            dispatch(setDiem(e.target.value));
                                        }}
                                    />
                                </div>

                                <div className="p-2">
                                    <Checkbox checked={type} onChange={(e) => {
                                        setType(e.target.checked)
                                    }}>
                                        Sửa theo đơn phúc khảo của học sinh
                                    </Checkbox>
                                </div>
                            </div>
                            <div className="text-center mt-3">

                                <Popconfirm
                                    className="ml-3"
                                    title="Sửa điểm thi"
                                    description="Bạn có chắc chắn muốn sửa điểm thi?"
                                    onConfirm={() => {
                                        dispatch(suaDiemThiAction(type ? 1 : 0, diemObject?.id, diem))
                                    }}
                                    //   onCancel={cancel}
                                    okText="Sửa điểm"
                                    cancelText="hủy"
                                >
                                    <Button type="primary" >Sửa điểm</Button>
                                </Popconfirm>

                            </div>
                        </div>
                    ) : (
                        <div></div>
                    )
                }
            </div>
        </div>
    )
}