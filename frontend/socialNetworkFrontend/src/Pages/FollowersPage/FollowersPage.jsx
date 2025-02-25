import React from 'react'
import styles from "../FollowersPage/FollowersPage.module.scss";
import Navigation from "../../Components/Navigation/Navigation.jsx";
import Aside from "../../Components/Aside/Aside.jsx";
import FollowersList from "../../Components/FollowersList/FollowersList.jsx";



export default function FollowersPage() {
    return (
        <div className={styles.wrapper}>
            <FollowersList />
            <Navigation/>
            <Aside/>
        </div>
    )
}
