import React from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  closeDrawerAction,
  stateDrawer,
} from "../../reducers/drawerReducer/drawerReducer";
import { Drawer } from "antd";

export default function DrawerComponent(props) {
  const { visiable, title, DrawerComponent , width} = useSelector(stateDrawer);

  const dispatch = useDispatch();

  return (
    <Drawer
      open={visiable}
      title={title}
      width={width}
      onClose={() => {
        dispatch(closeDrawerAction());
      }}
      okButtonProps={{ style: { display: "none" } }}
      cancelButtonProps={{ style: { display: "none" } }}
      headerStyle={{ className: "pd-5 " }}
      destroyOnClose={true}
    >
      {DrawerComponent}
    </Drawer>
  );
}
