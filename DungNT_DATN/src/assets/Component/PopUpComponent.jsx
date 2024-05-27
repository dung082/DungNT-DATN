import { Modal } from "antd";
import React from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  closeModalAction,
  statePopup,
} from "../../reducers/modalReducer/modalReducer";

export default function PopUpComponent(props) {
  const { visiable, title, ModalComponent } = useSelector(statePopup);

  const dispatch = useDispatch();

  return (
    <Modal
      open={visiable}
      title={title}
      width={600}
      height={800}
      onCancel={() => {
        dispatch(closeModalAction());
      }}
      okButtonProps={{ style: { display: "none" } }}
      cancelButtonProps={{ style: { display: "none" } }}
      headerStyle={{ className: "pd-5 " }}
      destroyOnClose={true}
    >
      {ModalComponent}
    </Modal>
  );
}
