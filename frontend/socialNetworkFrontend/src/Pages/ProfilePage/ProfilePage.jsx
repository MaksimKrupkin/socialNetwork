import React from 'react'
import styles from './ProfilePage.module.scss'
import FollowersList from "../../Components/FollowersList/FollowersList.jsx";
import Navigation from "../../Components/Navigation/Navigation.jsx";
import Aside from "../../Components/Aside/Aside.jsx";
import Profile from "../../Components/Profile/Profile.jsx";

export default function ProfilePage() {
    return (
        <div className={styles.wrapper}>
            <Profile/>
            <Navigation/>
            <Aside/>
        </div>
    )
}
