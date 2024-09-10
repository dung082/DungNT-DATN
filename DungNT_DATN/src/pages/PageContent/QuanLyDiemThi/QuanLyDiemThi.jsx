import { useDispatch } from "react-redux"

export default function QuanLyDiemThi(props) {

    const dispatch = useDispatch()


    return (
        <div>
            <div className="p-3">
                <div className=" bottem-border-title pb-2">
                    <div className="flex justify-between">
                        <div>
                            <span className="font-bold text-xl">QUẢN LÝ ĐIỂM THI</span>
                        </div>
                        <div>
                            {/* <Button type="primary" onClick={openDrawerEditUser}>
                    Sửa thông tin
                  </Button> */}
                        </div>
                    </div>
                </div>
                <div className="mt-3 flex justify-end px-5">
                    {/* <Button type="primary" className="mr-3" onClick={themDiemTongKet}>Thêm điểm tổng kết</Button>
                    <Button type="primary" className="mr-3" onClick={themDiemThi} >Thêm điểm thi</Button>
                    <Button type="primary" className="mr-3" onClick={suaDiemTongKet}>Tra cứu điểm tổng kết</Button>
                    <Button type="primary" className="mr-3" onClick={suaDiemThi} >Tra cứu điểm thi</Button> */}
                    {/* <Button type="primary" onClick={themHS}>Thêm mới học sinh</Button> */}
                </div>
            </div>
        </div>
    )
}