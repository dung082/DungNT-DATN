import { useDispatch, useSelector } from "react-redux"
import { getChiTietLichThiAction, lichThiState, setChiTietLichThi } from "../../../reducers/lichThiReducer/lichThiReducer"
import { useEffect } from "react"
import { globalState } from "../../../reducers/globalReducer/globalReducer"
import TableComponent from "../../../assets/Component/TableComponent"
import { HOC_SINH_CHI_TIET_THOI_KHOA_BIEU } from "../../../templates/tableConfig"

export default function ChiTietLichThi(props) {

    const { chiTietLichThi } = useSelector(lichThiState)
    const { userInfo } = useSelector(globalState)
    const dispatch = useDispatch()
    useEffect(() => {
        dispatch(getChiTietLichThiAction(props?.idLichThi, userInfo?.username))

        return () => {
            dispatch(setChiTietLichThi({}))
        }
    }, [])
    return (
        <div className="px-3">
            <div> <div className="py-2 title-detail">
                <span className="font-bold text-lg">Thông tin lịch thi</span>

            </div>

                <div className="mt-2">
                    <span>
                        Kỳ thi:{"   "}
                        <span className="font-bold">{chiTietLichThi?.lichthi?.tenKyThi}</span>
                    </span>
                </div>

                <div className="mt-2">
                    <span>
                        Khối thi:{"   "}
                        <span className="font-bold">Khối {chiTietLichThi?.lichthi?.khoiThi}</span>
                    </span>
                </div>

                <div className="mt-2">
                    <span>
                        Môn thi:{"   "}
                        <span className="font-bold">{chiTietLichThi?.lichthi?.tenMonThi}</span>
                    </span>
                </div>

                <div className="mt-2">
                    <span>
                        Ca thi:{"   "}
                        <span className="font-bold">{chiTietLichThi?.lichthi?.tenCaHoc}</span>
                    </span>
                </div>

                <div className="mt-2">
                    <span>
                        Phòng thi:{"   "}
                        <span className="font-bold">Phòng thi số {chiTietLichThi?.lichthi?.phongThi}</span>
                    </span>
                </div>

                <div className="mt-2">
                    <span>
                        Thời gian bắt đầu:{"   "}
                        <span className="font-bold">{chiTietLichThi?.lichthi?.thoiGianBatDau}</span>
                    </span>
                </div>

                <div className="mt-2">
                    <span>
                        Thời gian kết thúc:{"   "}
                        <span className="font-bold">{chiTietLichThi?.lichthi?.thoiGianKetThuc}</span>
                    </span>
                </div>
            </div>

            <div>
                <div className="py-2 title-detail mt-5">
                    <span className="font-bold text-lg">Thông tin phòng thi</span>
                </div>

                <div>
                    {chiTietLichThi?.listngdphongthi?.map((item, index) => {
                        return (
                            <div key={index}>
                                <span className="font-bold text-lg">Danh sách học sinh phòng thi số {index + 1}</span>
                                <TableComponent
                                    className="mt-3"
                                    ColumnConfig={HOC_SINH_CHI_TIET_THOI_KHOA_BIEU}
                                    DataSource={item}
                                    CurrentPage={1}
                                    CurrentPageSize={24}

                                />
                            </div>
                        )
                    })
                    }
                </div>
            </div>
        </div>
    )
}