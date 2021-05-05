﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rabbit_chat.Models;

namespace rabbit_chat.Migrations
{
    [DbContext(typeof(RabbitChatContext))]
    [Migration("20210504165317_RestructuredRelationshipsUntestedAddedBackFriendCollection")]
    partial class RestructuredRelationshipsUntestedAddedBackFriendCollection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("RabbitUserRoom", b =>
                {
                    b.Property<int>("RoomsRoomId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersRabbitUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RoomsRoomId", "UsersRabbitUserId");

                    b.HasIndex("UsersRabbitUserId");

                    b.ToTable("RabbitUserRoom");
                });

            modelBuilder.Entity("rabbit_chat.Models.ActBed", b =>
                {
                    b.Property<int>("ActBedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ActBedInfectionActInfectionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ActBedName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ActBedWorkflowActWorkflowId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ActRoomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ActBedId");

                    b.HasIndex("ActBedInfectionActInfectionId");

                    b.HasIndex("ActBedWorkflowActWorkflowId");

                    b.HasIndex("ActRoomId");

                    b.ToTable("ActBeds");
                });

            modelBuilder.Entity("rabbit_chat.Models.ActInfection", b =>
                {
                    b.Property<int>("ActInfectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ActInfectionName")
                        .HasColumnType("TEXT");

                    b.HasKey("ActInfectionId");

                    b.ToTable("ActInfections");
                });

            modelBuilder.Entity("rabbit_chat.Models.ActRoom", b =>
                {
                    b.Property<int>("ActRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ActRoomName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ActUnitId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ActRoomId");

                    b.HasIndex("ActUnitId");

                    b.ToTable("ActRooms");
                });

            modelBuilder.Entity("rabbit_chat.Models.ActUnit", b =>
                {
                    b.Property<int>("ActUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ActUnitName")
                        .HasColumnType("TEXT");

                    b.HasKey("ActUnitId");

                    b.ToTable("ActUnits");
                });

            modelBuilder.Entity("rabbit_chat.Models.ActWorkflow", b =>
                {
                    b.Property<int>("ActWorkflowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ActWorkflowText")
                        .HasColumnType("TEXT");

                    b.HasKey("ActWorkflowId");

                    b.ToTable("ActWorkflows");
                });

            modelBuilder.Entity("rabbit_chat.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MessageContent")
                        .HasColumnType("TEXT");

                    b.Property<int>("RabbitUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("TimeSent")
                        .HasColumnType("TEXT");

                    b.HasKey("MessageId");

                    b.HasIndex("RoomId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("rabbit_chat.Models.RabbitUser", b =>
                {
                    b.Property<int>("RabbitUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alias")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RabbitUserId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("TEXT");

                    b.Property<string>("Token")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("RabbitUserId");

                    b.HasIndex("RabbitUserId1");

                    b.ToTable("RabbitUsers");
                });

            modelBuilder.Entity("rabbit_chat.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoomName")
                        .HasColumnType("TEXT");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("RabbitUserRoom", b =>
                {
                    b.HasOne("rabbit_chat.Models.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rabbit_chat.Models.RabbitUser", null)
                        .WithMany()
                        .HasForeignKey("UsersRabbitUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("rabbit_chat.Models.ActBed", b =>
                {
                    b.HasOne("rabbit_chat.Models.ActInfection", "ActBedInfection")
                        .WithMany()
                        .HasForeignKey("ActBedInfectionActInfectionId");

                    b.HasOne("rabbit_chat.Models.ActWorkflow", "ActBedWorkflow")
                        .WithMany()
                        .HasForeignKey("ActBedWorkflowActWorkflowId");

                    b.HasOne("rabbit_chat.Models.ActRoom", null)
                        .WithMany("ActRoomBeds")
                        .HasForeignKey("ActRoomId");

                    b.Navigation("ActBedInfection");

                    b.Navigation("ActBedWorkflow");
                });

            modelBuilder.Entity("rabbit_chat.Models.ActRoom", b =>
                {
                    b.HasOne("rabbit_chat.Models.ActUnit", null)
                        .WithMany("ActUnitRooms")
                        .HasForeignKey("ActUnitId");
                });

            modelBuilder.Entity("rabbit_chat.Models.Message", b =>
                {
                    b.HasOne("rabbit_chat.Models.Room", "Room")
                        .WithMany("Messages")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("rabbit_chat.Models.RabbitUser", b =>
                {
                    b.HasOne("rabbit_chat.Models.RabbitUser", null)
                        .WithMany("Friends")
                        .HasForeignKey("RabbitUserId1");
                });

            modelBuilder.Entity("rabbit_chat.Models.ActRoom", b =>
                {
                    b.Navigation("ActRoomBeds");
                });

            modelBuilder.Entity("rabbit_chat.Models.ActUnit", b =>
                {
                    b.Navigation("ActUnitRooms");
                });

            modelBuilder.Entity("rabbit_chat.Models.RabbitUser", b =>
                {
                    b.Navigation("Friends");
                });

            modelBuilder.Entity("rabbit_chat.Models.Room", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
